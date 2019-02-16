using UnityEngine;

public class SpawnChildrenEffect : MonoBehaviour, IEnemyPowerEffect
{

    public EnemyType childrenType;
    public int minChildrenToSpawn;
    public int maxChildrenToSpawn;
    public float childrenSpawnOffset = 2;

    private Enemy parent;

    void Start()
    {
        parent = GetComponent<Enemy>();
    }

    public void ApplyEffect()
    {
        var childAmount = Random.Range(minChildrenToSpawn, maxChildrenToSpawn + 1);

        for (int i = 0; i < childAmount; i++)
        {
            var child = EnemyManager.Instance.GetEnemy(childrenType);
            var offset = Random.Range(-childrenSpawnOffset, childrenSpawnOffset);

            child.transform.position = transform.position + transform.forward * offset;
            child.Movement.SetWaypoint(parent.Movement);
        }
    }

}
