using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Item")]
    public CollectibleType type;

    [Header("Score")]
    public int scoreValue = 1;

    [Header("Animation")]
    public Animator animator;

    private bool collected = false;

    public void Collect()
    {
        if (collected)
            return;

        collected = true;

        ScoreManager.Instance.AddScore(scoreValue);

        FloatingTextManager.Instance.ShowText(
            scoreValue > 0 ? "+" + scoreValue : scoreValue.ToString(),
            transform.position);

        AudioManager.Instance.PlayCoin();

        EffectManager.Instance.PlayCoinEffect(transform.position);

        animator.SetTrigger("Collect");

        GetComponent<Collider2D>().enabled = false;

        GetComponent<CoinMovement>().enabled = false;

        Destroy(gameObject, 0.8f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
}