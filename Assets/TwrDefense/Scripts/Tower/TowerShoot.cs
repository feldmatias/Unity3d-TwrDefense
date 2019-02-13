using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public BulletType bulletType;
    public GameObject rotationPart;
    public Transform shootingPosition;

    [Header("Enemy")]
    public bool attackGroundEnemies = true;
    public bool attackFlyingEnemies = false;

    private Tower tower;
    private float fireTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
    }

    private void Update()
    {
        if (!tower.IsActive)
        {
            return;
        }

        Attack();
    }

    protected virtual void Attack()
    {
        fireTimer -= Time.deltaTime;

        Enemy target = null;

        if (attackGroundEnemies)
        {
            target = GetGroundTarget();
        } else if (attackFlyingEnemies)
        {
            target = GetFlyingTarget();
        }

        Rotate(target);

        if (fireTimer <= 0)
        {
            if (target != null)
            {
                fireTimer = tower.Stats.FireRate.Value;
                Shoot(target);
            }
        }
    }

    private void Rotate(Enemy target)
    {
        if (rotationPart != null && target != null)
        {
            var dir = target.transform.position - transform.position;
            dir.y = 0;
            rotationPart.transform.forward = dir.normalized;
        }
    }

    private void Shoot(Enemy target)
    {
        var bullet = BulletManager.Instance.GetBullet(bulletType);
        bullet.transform.position = shootingPosition.position;
        bullet.transform.forward = shootingPosition.forward;
        bullet.Target = target;
        bullet.Damage = tower.Stats.Damage.Value;

        tower.AudioManager.PlayShootAudio();
    }

    private Enemy GetGroundTarget()
    {
        return GetTarget(transform.position, Layers.GROUND_ENEMY);
    }

    private Enemy GetFlyingTarget()
    {
        var flyingPosition = transform.position;
        flyingPosition.y = EnemyManager.FlyingEnemiesSpawnPosition.position.y;

        return GetTarget(flyingPosition, Layers.FLYING_ENEMY);
    }

    private Enemy GetTarget(Vector3 position, string layer)
    {
        var hits = Physics.OverlapSphere(position, tower.Stats.AttackRadius.Value, Layers.GetLayerMask(layer));
        if (hits.Length == 0)
        {
            return null;
        }

        float maxProgress = 0;
        Enemy maxProgressEnemy = null;
        foreach (var hit in hits)
        {
            var enemy = hit.gameObject.GetComponent<Enemy>();
            var progress = enemy.ProgressToPlayerBase;
            if (progress > maxProgress)
            {
                maxProgress = progress;
                maxProgressEnemy = enemy;
            }
        }

        return maxProgressEnemy;
    }
}
