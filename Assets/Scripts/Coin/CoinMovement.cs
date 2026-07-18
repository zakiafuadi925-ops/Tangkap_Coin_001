using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float idleSpeed = 1.5f;
    public float fallSpeed = 5f;
    public float idleDuration = 1f;

    private Animator animator;
    private bool isFalling = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke(nameof(StartFall), idleDuration);
    }

    void Update()
    {
        float speed = isFalling ? fallSpeed : idleSpeed;
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void StartFall()
    {
        isFalling = true;
        animator.SetTrigger("StartFall");
    }
}