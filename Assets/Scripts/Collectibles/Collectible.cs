using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] private CollectibleType itemType;

    [Header("Gameplay")]
    [SerializeField] private int scoreValue = 1;

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
        ScoreManager.Instance.AddScore(scoreValue);

        // Floating Text
        string text = scoreValue > 0 ? "+" + scoreValue : scoreValue.ToString();
        FloatingTextManager.Instance.ShowText(text, transform.position);

        // Audio
        AudioManager.Instance.Play(itemType);

        // Effect
        EffectManager.Instance.PlayCoinEffect(transform.position);

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