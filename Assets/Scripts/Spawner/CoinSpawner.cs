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
}