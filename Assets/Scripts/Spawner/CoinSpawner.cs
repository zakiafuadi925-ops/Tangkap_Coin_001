using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Coin Prefab")]
    

    [Header("Spawn Area")]
    public float minX = -2.5f;
    public float maxX = 2.5f;
    public float spawnY = 5f;

    [Header("Spawn Time")]
    public float spawnInterval = 1.5f;
    public GameObject coinPrefab;

    

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
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
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