using TMPro;
using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int CurrentScore
    {
        get { return score; }
    }

    [Header("UI")]
    public TextMeshProUGUI scoreText;

    [Header("Score")]
    [SerializeField] private int score = 0;


    private Vector3 originalScale;

    [SerializeField] private float popScale = 1.25f;
    [SerializeField] private float popDuration = 0.15f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        originalScale = scoreText.transform.localScale;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
         StopAllCoroutines();
        StartCoroutine(PopAnimation());
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "coin " + score.ToString("000000");
    }

    IEnumerator PopAnimation()
    {
        scoreText.transform.localScale = originalScale * popScale;

        yield return new WaitForSeconds(popDuration);

        scoreText.transform.localScale = originalScale;
    }
}