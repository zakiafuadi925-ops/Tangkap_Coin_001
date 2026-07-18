using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator animator;
    private Collider2D coinCollider;
    private CoinMovement coinMovement;

    private bool collected = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        coinCollider = GetComponent<Collider2D>();
        coinMovement = GetComponent<CoinMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            // Tambah score
            ScoreManager.Instance.AddScore(1);
            FloatingTextManager.Instance.ShowText("+1", transform.position);

            // Hentikan gerakan coin
            coinMovement.enabled = false;

            // Matikan collider supaya tidak terhitung dua kali
            coinCollider.enabled = false;

            // Jalankan animasi collect
            animator.SetTrigger("Collect");

            // Hapus coin setelah animasi selesai
            Destroy(gameObject, 0.5f);
        }
    }
}