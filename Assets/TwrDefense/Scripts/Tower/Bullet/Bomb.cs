﻿using UnityEngine;

public class Bomb : Bullet
{
    [Header("Explosion")]
    public float explosionRadius;
    public float explosionDamageMultiplier = 0.3f;

    protected override void DamageTarget()
    {
        base.DamageTarget();
        Explode();
    }

    private void Explode()
    {
        ExplosionManager.Instance.MakeExplosion(transform.position);

        var enemies = Physics.OverlapSphere(transform.position, explosionRadius, Layers.GetLayerMask(Layers.GROUND_ENEMY));

        foreach (var enemy in enemies)
        {
            if (enemy.gameObject == Target.gameObject)
            {
                continue; //Do not damage again target
            }

            DamageEnemy(enemy.gameObject, Damage * explosionDamageMultiplier);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
