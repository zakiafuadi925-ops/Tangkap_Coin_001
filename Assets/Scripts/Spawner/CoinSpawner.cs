using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Collectible Prefabs")]
    [SerializeField]
    private SpawnData[] collectibles;

    [Header("Spawn Area")]
    public float minX = -2.5f;
    public float maxX = 2.5f;
    public float spawnY = 5f;

    IEnumerator Start()
    {
        while (true)
        {
            SpawnCollectible();

            yield return new WaitForSeconds(
                DifficultyManager.Instance.GetSpawnInterval());
        }
    }

    void SpawnCollectible()
    {
        GameObject prefab = GetRandomCollectible();

        Debug.Log(prefab.name);


        if (prefab == null)
        {
            Debug.LogError("Prefab masih kosong!");
            return;
        }

        Vector3 spawnPos = new Vector3(
            Random.Range(minX, maxX),
            spawnY,
            0);

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    GameObject GetRandomCollectible()
    {
        int totalWeight = 0;

        foreach (SpawnData item in collectibles)
        {
            totalWeight += item.weight;
        }

        int random = Random.Range(0, totalWeight);

        foreach (SpawnData item in collectibles)
        {
            if (random < item.weight)
                return item.prefab;

            random -= item.weight;
        }

        return collectibles[0].prefab;
    }
}