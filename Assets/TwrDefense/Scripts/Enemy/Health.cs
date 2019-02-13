using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;

    private IDeathable target;

    private float health;
    private bool isDead = false;

    public float HealthPercentage { get { return health / maxHealth; } }
    public int CurrentHealth { get { return Mathf.FloorToInt(health); } }

    private void Start()
    {
        health = maxHealth;
        target = GetComponent<IDeathable>();
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
