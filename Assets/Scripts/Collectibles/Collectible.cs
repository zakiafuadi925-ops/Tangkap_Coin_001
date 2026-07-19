using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] private CollectibleType itemType;

    [Header("Gameplay")]
    [SerializeField] private int scoreValue = 0;

    [SerializeField] private int lifeChange = 0;

    private Animator animator;
    private Collider2D itemCollider;
    private CoinMovement coinMovement;

    private bool collected = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        itemCollider = GetComponent<Collider2D>();
        coinMovement = GetComponent<CoinMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected)
            return;

        if (!other.CompareTag("Player"))
            return;

        collected = true;

        // Tambah / Kurangi Score
        // Score
        if (scoreValue != 0)
        {
            ScoreManager.Instance.AddScore(scoreValue);
        }

        // Life
        if (lifeChange > 0)
        {
            LifeManager.Instance.AddLife(lifeChange);
        }
        else if (lifeChange < 0)
        {
            LifeManager.Instance.RemoveLife(-lifeChange);
        }

        // Floating Text
        string text = "";
        if (scoreValue > 0)
        {
            text = "+" + scoreValue;
        }
        else if (scoreValue < 0)
        {
            text = scoreValue.ToString();
        }
        else if (lifeChange > 0)
        {
            text = "+❤";
        }
        else if (lifeChange < 0)
        {
            text = "-❤";
        }

        if (!string.IsNullOrEmpty(text))
        {
            FloatingTextManager.Instance.ShowText(text, transform.position);
        }

        // Audio
        AudioManager.Instance.Play(itemType);

        // Effect
        EffectManager.Instance.Play(itemType, transform.position);

        // Hentikan gerakan
        if (coinMovement != null)
            coinMovement.enabled = false;

        // Matikan collider
        if (itemCollider != null)
            itemCollider.enabled = false;

        // Jalankan animasi
        if (animator != null)
            animator.SetTrigger("Collect");

        Destroy(gameObject, 0.5f);
    }
}