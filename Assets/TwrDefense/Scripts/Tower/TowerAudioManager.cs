using UnityEngine;

public class TowerAudioManager : MonoBehaviour
{

    [Header("Audios")]
    public AudioClip upgradeAudio;
    public AudioClip shootAudio;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void PlayUpgradeAudio()
    {
        PlayAudio(upgradeAudio);
    }

    public void PlayShootAudio()
    {
        PlayAudio(shootAudio);
    }
}
