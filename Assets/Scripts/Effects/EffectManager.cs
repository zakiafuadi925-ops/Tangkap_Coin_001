using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    [Header("Effects")]
    [SerializeField] private GameObject coinEffect;
    [SerializeField] private GameObject bombEffect;
    [SerializeField] private GameObject diamondEffect;
    [SerializeField] private GameObject heartEffect;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Play(CollectibleType type, Vector3 position)
    {
        GameObject effect = null;

        switch (type)
        {
            case CollectibleType.Coin:
                effect = coinEffect;
                break;

            case CollectibleType.Bomb:
                effect = bombEffect;
                break;

            case CollectibleType.Diamond:
                effect = diamondEffect;
                break;

            case CollectibleType.Heart:
                effect = heartEffect;
                break;
        }

        if (effect != null)
        {
            GameObject obj = Instantiate(effect, position, Quaternion.identity);
            Destroy(obj, 1f);
        }
    }
}