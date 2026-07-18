using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource sfxSource;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip coinClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayCoin()
    {
        if (sfxSource == null)
        {
            Debug.LogWarning("AudioSource belum dihubungkan.");
            return;
        }

        if (coinClip == null)
        {
            Debug.LogWarning("Coin Clip belum dihubungkan.");
            return;
        }

        sfxSource.PlayOneShot(coinClip);
    }
}