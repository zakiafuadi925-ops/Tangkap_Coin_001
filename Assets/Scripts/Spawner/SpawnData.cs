using UnityEngine;

[System.Serializable]
public class SpawnData
{
    public GameObject prefab;

    [Range(1,100)]
    public int weight = 10;
}