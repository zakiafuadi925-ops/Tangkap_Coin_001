using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    [Header("Spawn")]
    [SerializeField] private float startSpawnInterval = 1.5f;
    [SerializeField] private float minimumSpawnInterval = 0.4f;
    [SerializeField] private float spawnDecreasePerScore = 0.01f;

    [Header("Coin Fall")]
    [SerializeField] private float startFallSpeed = 2f;
    [SerializeField] private float maximumFallSpeed = 6f;
    [SerializeField] private float fallIncreasePerScore = 0.02f;

    private void Awake()
    {
        Instance = this;
    }

    public float GetSpawnInterval()
    {
        int score = ScoreManager.Instance.CurrentScore;

        float interval = startSpawnInterval - (score * spawnDecreasePerScore);

        return Mathf.Max(minimumSpawnInterval, interval);
    }

    public float GetCoinFallSpeed()
    {
        int score = ScoreManager.Instance.CurrentScore;

        float speed = startFallSpeed + (score * fallIncreasePerScore);

        return Mathf.Min(maximumFallSpeed, speed);
    }

    public float GetFallSpeedMultiplier()
    {
        int score = ScoreManager.Instance.CurrentScore;

        return Mathf.Min(2f, 1f + score * 0.01f);
    }
}