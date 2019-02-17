using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;

    private IDeathable deathableTarget;
    private IDamageable damageableTarget;

    private float health;
    private float currentMaxHealth;
    private bool isDead;

    public float HealthPercentage { get { return health / currentMaxHealth; } }
    public int CurrentHealth { get { return Mathf.FloorToInt(health); } }

    private void Awake()
    {
        deathableTarget = GetComponent<IDeathable>();
        damageableTarget = GetComponent<IDamageable>();
        currentMaxHealth = maxHealth;
        Reset();
    }

    public void SetMaxHealth(float multiplier)
    {
        currentMaxHealth = maxHealth * multiplier;
        Reset();
    }

    public void Reset()
    {
        health = currentMaxHealth;
        isDead = false;
    }

    public void ReceiveDamage(float damage)
    {
        if (isDead)
        {
            return;
        }

        health = Mathf.Clamp(health - damage, 0, currentMaxHealth);

        if (damageableTarget != null)
        {
            damageableTarget.DamageReceived();
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void RestoreHealth(float heal)
    {
        if (isDead)
        {
            return;
        }

        health = Mathf.Clamp(health + heal, 0, currentMaxHealth);
    }

    public void HealPercentage(float percentage)
    {
        RestoreHealth(currentMaxHealth * percentage);
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
