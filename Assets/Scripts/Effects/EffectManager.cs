using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    [SerializeField] private GameObject coinEffectPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayCoinEffect(Vector3 position)
    {
        GameObject effect = Instantiate(coinEffectPrefab, position, Quaternion.identity);

        Destroy(effect, 1f);
    }
}