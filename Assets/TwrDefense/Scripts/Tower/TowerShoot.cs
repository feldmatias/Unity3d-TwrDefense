using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public BulletType bulletType;
    public GameObject rotationPart;
    public Transform shootingPosition;

    private Tower tower;
    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
        fireTimer = tower.Stats.FireRate.Value;
    }

    private void Update()
    {
        if (!tower.IsActive)
        {
            return;
        }

        fireTimer -= Time.deltaTime;

        Enemy target = GetTarget();
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

    private Enemy GetTarget()
    {
        var hits = Physics.OverlapSphere(transform.position, tower.Stats.AttackRadius.Value, LayerMasks.GROUND_ENEMY);
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
