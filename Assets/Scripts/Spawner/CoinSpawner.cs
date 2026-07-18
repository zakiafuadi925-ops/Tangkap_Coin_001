using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public float spawnInterval = 1.5f;

    IEnumerator Start()
    {
        while (true)
        {
            SpawnCoin();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCoin()
    {
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        int score = ScoreManager.Instance.CurrentScore;

        if (score >= 100)
            spawnInterval = 0.7f;
        else if (score >= 50)
            spawnInterval = 0.9f;
        else if (score >= 20)
            spawnInterval = 1.2f;
        else
            spawnInterval = 1.5f;
    }
}