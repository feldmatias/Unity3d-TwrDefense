using UnityEngine;

public class TowerAudioManager : MonoBehaviour
{

    [Header("Audios")]
    public AudioClip buyAudio;
    public AudioClip upgradeAudio;
    public AudioClip shootAudio;

    private AudioSource audioSource;

    private bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
        isShooting = false;
    }

    public void PlayBuyAudio()
    {
        PlayAudio(buyAudio);
    }

    public void PlayUpgradeAudio()
    {
        PlayAudio(upgradeAudio);
    }

    public void PlayShootAudio()
    {
        if (audioSource.isPlaying && isShooting)
        {
            return;
        }
        PlayAudio(shootAudio);
        isShooting = true;
    }
}
