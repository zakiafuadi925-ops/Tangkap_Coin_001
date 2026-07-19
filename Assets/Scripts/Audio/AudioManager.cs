using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource sfxSource;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip bombClip;
    [SerializeField] private AudioClip diamondClip;
    [SerializeField] private AudioClip heartClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Play(CollectibleType type)
    {
        if (sfxSource == null)
            return;

        AudioClip clip = null;

        switch (type)
        {
            case CollectibleType.Coin:
                clip = coinClip;
                break;

            case CollectibleType.Bomb:
                clip = bombClip;
                break;

            case CollectibleType.Diamond:
                clip = diamondClip;
                break;

            case CollectibleType.Heart:
                clip = heartClip;
                break;
        }

        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }
}