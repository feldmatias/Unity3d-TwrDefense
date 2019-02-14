using UnityEngine;

public class TowerMultipleShoot : TowerShoot
{
    protected override void Attack()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0)
        {
            fireTimer = tower.Stats.FireRate.Value;

            if (attackGroundEnemies)
            {
                AttackGroundEnemies();
            }

            if (attackFlyingEnemies)
            {
                AttackFlyingEnemies();
            }

        }
    }

    private void AttackGroundEnemies()
    {
        AttackEnemies(transform.position, Layers.GROUND_ENEMY);
    }

    private void AttackFlyingEnemies()
    {
        var flyingPosition = transform.position;
        flyingPosition.y = EnemyManager.FlyingEnemiesSpawnPosition.position.y;

        AttackEnemies(flyingPosition, Layers.FLYING_ENEMY);
    }

    private void AttackEnemies(Vector3 position, string layer)
    {
        var hits = Physics.OverlapSphere(position, tower.Stats.AttackRadius.Value, Layers.GetLayerMask(layer));

        foreach (var enemy in hits)
        {
            Shoot(enemy.GetComponent<Enemy>());
        }
    }

}
