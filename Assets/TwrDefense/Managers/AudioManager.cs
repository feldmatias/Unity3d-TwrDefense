using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audios")]
    public AudioClip sellTowerAudio;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void PlayTowerSellAudio()
    {
        PlayAudio(sellTowerAudio);
    }
}
