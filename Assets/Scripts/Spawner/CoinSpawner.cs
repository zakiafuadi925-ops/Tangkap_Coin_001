using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Coin Prefab")]
    public GameObject coinPrefab;

    [Header("Spawn Area")]
    public float minX = -2.5f;
    public float maxX = 2.5f;
    public float spawnY = 5f;

    IEnumerator Start()
    {
        while (true)
        {
            SpawnCoin();

            yield return new WaitForSeconds(
                DifficultyManager.Instance.GetSpawnInterval());
        }
    }

    void SpawnCoin()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}