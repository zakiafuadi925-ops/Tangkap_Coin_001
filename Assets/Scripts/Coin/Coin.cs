using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator animator;
    private bool collected = false;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;
        if (other.CompareTag("Player"))
        {
            collected = true;
            animator.SetTrigger("Collect");

            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;

            Destroy(gameObject, 0.4f);
        }
    }
}