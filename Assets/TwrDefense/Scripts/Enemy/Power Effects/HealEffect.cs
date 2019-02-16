using UnityEngine;

public class HealEffect : MonoBehaviour, IEnemyPowerEffect
{

    public float maxHealthPercentageRestore = 0.7f;
    public float healRadius = 5;


    public void ApplyEffect()
    {
        var hits = Physics.OverlapSphere(transform.position, healRadius, Layers.GetLayerMask(Layers.GROUND_ENEMY));

        foreach (var hit in hits)
        {
            var enemy = hit.GetComponent<Enemy>();
            if (enemy != null && enemy.gameObject != gameObject && !enemy.IsDead)
            {
                enemy.Health.HealPercentage(maxHealthPercentageRestore);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, healRadius);
    }
}
