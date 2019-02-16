using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;

    private IDeathable deathableTarget;
    private IDamageable damageableTarget;

    private float health;
    private bool isDead;

    public float HealthPercentage { get { return health / maxHealth; } }
    public int CurrentHealth { get { return Mathf.FloorToInt(health); } }

    private void Awake()
    {
        deathableTarget = GetComponent<IDeathable>();
        damageableTarget = GetComponent<IDamageable>();
        Reset();
    }

    public void Reset()
    {
        health = maxHealth;
        isDead = false;
    }

    public void ReceiveDamage(float damage)
    {
        if (isDead)
        {
            return;
        }

        health = Mathf.Clamp(health - damage, 0, maxHealth);

        if (damageableTarget != null)
        {
            damageableTarget.DamageReceived();
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        if (deathableTarget != null)
        {
            deathableTarget.Die();
        }
    }
}
