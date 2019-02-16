using UnityEngine;

public class PlayerBase : MonoBehaviour, IDeathable, IDamageable
{
    public static Health Health { get; private set; }

    public GameObject gameOverEffect;

    private AudioSource audioSource;

    private void Awake()
    {
        Health = GetComponent<Health>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Die()
    {
        gameOverEffect.SetActive(true);
        GameCamera.gameCamera.SetGameOverPosition(transform.position);
        GameManager.Instance.GameOver();
    }

    public void DamageReceived()
    {
        audioSource.Play();
    }

}
