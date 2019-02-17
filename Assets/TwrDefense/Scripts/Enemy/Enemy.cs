using UnityEngine;

public class Enemy : MonoBehaviour, IDeathable
{
    public Transform ShootingPosition;
    public Health Health { get; private set; }
    public EnemyMovement Movement { get; private set; }

    [Header("Attack Player Base")]
    public float damage = 10;

    [Header("Rewards")]
    public int coinsReward;

    protected Animator animator;
    private AudioSource audioSource;
    
    public bool IsDead { get; private set; }
    public float ProgressToPlayerBase { get { return Movement.ProgressToPlayerBase; } }

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        Movement = GetComponent<EnemyMovement>();
        Health = GetComponent<Health>();
    }

    void OnEnable()
    {
        IsDead = false;
        animator.SetTrigger(EnemyAnimator.RESET_TRIGGER);
        Movement.Enable();
        Health.SetMaxHealth(WaveManager.Instance.Difficulty);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerBase>();
        if (player != null)
        {
            PlayerBase.Health.ReceiveDamage(damage);
            IsDead = true;
            Delete();
        }
    }

    private void Delete()
    {
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }

    public virtual void Die()
    {
        IsDead = true;

        PlayerCoins.AddCoins(coinsReward);
        animator.SetTrigger(EnemyAnimator.DEAD_TRIGGER);
        audioSource.Play();

        Movement.Disable();

        Invoke("Delete", 5);
    }
}
