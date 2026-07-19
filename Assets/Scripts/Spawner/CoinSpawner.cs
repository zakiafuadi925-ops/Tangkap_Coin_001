using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Collectible Prefabs")]
    [SerializeField] private GameObject[] collectiblePrefabs;

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
        int randomIndex = Random.Range(0, collectiblePrefabs.Length);

        Instantiate(
            collectiblePrefabs[randomIndex],
            transform.position,
            Quaternion.identity);
    }
}