using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public float gameplayVolume = 0.1f;
    public float menuVolume = 1f;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void SetGameplayMusic()
    {
        audioSource.volume = gameplayVolume;
    }

    public void SetMenuMusic()
    {
        audioSource.volume = menuVolume;
    }
}
