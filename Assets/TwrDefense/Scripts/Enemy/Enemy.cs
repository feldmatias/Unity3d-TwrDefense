using UnityEngine;

public class Enemy : MonoBehaviour, IDeathable
{
    public Transform ShootingPosition;
    public Health Health { get; private set; }

    [Header("Attack Player Base")]
    public float damage = 10;

    [Header("Rewards")]
    public int coinsReward;

    private Animator animator;
    private AudioSource audioSource;
    protected EnemyMovement movement;
    
    public bool IsDead { get; private set; }
    public float ProgressToPlayerBase { get { return movement.ProgressToPlayerBase; } }

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        movement = GetComponent<EnemyMovement>();
        Health = GetComponent<Health>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        IsDead = false;
        animator.SetTrigger(EnemyAnimator.RESET_TRIGGER);
        movement.Enable();
        Health.Reset();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerBase>();
        if (player != null)
        {
            PlayerBase.Health.ReceiveDamage(damage);
            Delete();
        }
    }

    private void Delete()
    {
        gameObject.SetActive(false);
    }

    public virtual void Die()
    {
        IsDead = true;

        PlayerCoins.AddCoins(coinsReward);
        animator.SetTrigger(EnemyAnimator.DEAD_TRIGGER);
        audioSource.Play();

        movement.Disable();

        Invoke("Delete", 5);
    }
}
