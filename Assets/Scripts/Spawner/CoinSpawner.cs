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

        


        if (prefab == null)
        {
            Debug.LogError("Prefab masih kosong!");
            return;
        }

        Debug.Log("Spawn : " + prefab.name);

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
            Debug.Log($"Item: {(item.prefab != null ? item.prefab.name : "NULL")}  Weight: {item.weight}");

            totalWeight += item.weight;
        }

        Debug.Log("Total Weight = " + totalWeight);

        int random = Random.Range(0, totalWeight);

        Debug.Log("Random = " + random);

        foreach (SpawnData item in collectibles)
        {
            if (random < item.weight)
            {
                Debug.Log("Selected = " + item.prefab.name);
                return item.prefab;
            }

            random -= item.weight;
        }

        return collectibles[0].prefab;
    }
}