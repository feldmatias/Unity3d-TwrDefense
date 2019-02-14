using UnityEngine;

public class SlowDownBullet : Bullet
{
    [Header("Slow Down")]
    public float velocityMultiplier = 0.5f;
    public float duration = 1;

    protected override void DamageTarget()
    {
        base.DamageTarget();
        Target.Movement.SlowDown(velocityMultiplier, duration);
    }
}
