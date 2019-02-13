using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;

    private IDeathable target;

    private float health;
    private bool isDead;

    public float HealthPercentage { get { return health / maxHealth; } }
    public int CurrentHealth { get { return Mathf.FloorToInt(health); } }

    private void Awake()
    {
        target = GetComponent<IDeathable>();
        Reset();
    }

    public void Reset()
    {
        health = maxHealth;
        isDead = false;
    }

    public void ReceiveDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        target.Die();
    }
}
