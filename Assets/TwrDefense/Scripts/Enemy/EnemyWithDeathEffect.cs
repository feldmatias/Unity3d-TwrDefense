using UnityEngine;

public class EnemyWithDeathEffect : Enemy
{

    private IEnemyPowerEffect deathEffect;

    protected override void Awake()
    {
        base.Awake();
        deathEffect = GetComponent<IEnemyPowerEffect>();
    }

    public override void Die()
    {
        deathEffect.ApplyEffect();
        base.Die();
    }

}
