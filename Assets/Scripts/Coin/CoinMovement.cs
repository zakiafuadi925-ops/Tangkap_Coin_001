using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float minIdleSpeed = 1f;
    public float maxIdleSpeed = 2f;
    public float minFallSpeed = 4f;
    public float maxFallSpeed = 7f;
    public float minIdleTime = 0.5f;
    public float maxIdleTime = 1.5f;


    private float idleSpeed;
    private float fallSpeed;
    private Animator animator;
    private bool isFalling = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        idleSpeed = Random.Range(minIdleSpeed, maxIdleSpeed);
        fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);

        float idleTime = Random.Range(minIdleTime, maxIdleTime);
        Invoke(nameof(StartFall), idleTime);
    }

    void Update()
    {
        float difficultyMultiplier =
            DifficultyManager.Instance.GetCoinFallSpeed();

        float speed = isFalling
            ? fallSpeed * difficultyMultiplier
            : idleSpeed;

        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void StartFall()
    {
        isFalling = true;
        animator.SetTrigger("StartFall");
    }
}