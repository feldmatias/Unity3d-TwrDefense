using UnityEngine;

public class EnemyWithChildren : Enemy
{

    [Header("Children")]
    public EnemyType childrenType;
    public int minChildrenToSpawn;
    public int maxChildrenToSpawn;
    public float childrenSpawnOffset = 1;

    public override void Die()
    {
        SpawnChildren();
        base.Die();
    }

    private void SpawnChildren()
    {
        var childAmount = Random.Range(minChildrenToSpawn, maxChildrenToSpawn + 1);

        for (int i = 0; i < childAmount; i++)
        {
            var child = EnemyManager.Instance.GetEnemy(childrenType);
            var offset = Random.Range(-childrenSpawnOffset, childrenSpawnOffset);

            child.transform.position = transform.position + transform.forward * offset;
            child.GetComponent<EnemyMovement>().SetWaypoint(movement);
        }
    }
}
