using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[Serializable]
public class EnemyData
{
    public EnemyType type;
    public GameObject prefab;
    public bool enemyFlies = false;

    [HideInInspector]
    public List<Enemy> list;
}

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager Instance;

    public EnemyData[] enemies;
    public Transform enemyHolder;
    public int enemiesToCreate = 50;

    public static List<GameObject> EnemyWaypoints;

    public static Transform GroundEnemiesSpawnPosition;
    public static Transform FlyingEnemiesSpawnPosition;

    private void Awake()
    {
        Instance = this;

        GroundEnemiesSpawnPosition = GameObject.FindGameObjectWithTag(Tags.GROUND_ENEMY_SPAWN).transform;
        FlyingEnemiesSpawnPosition = GameObject.FindGameObjectWithTag(Tags.FLYING_ENEMY_SPAWN).transform;

        EnemyWaypoints = GameObject.FindGameObjectsWithTag(Tags.ENEMY_WAYPOINT).OrderBy(w => w.name).ToList();

        foreach (var enemyData in enemies)
        {
            for (int i = 0; i < enemiesToCreate; i++)
            {
                InstantiateEnemy(enemyData.prefab, enemyData.list);
            }
        }
    }

    public int GetLastWaypointIndex()
    {
        return EnemyWaypoints.Count - 1;
    }

    public static Transform GetWaypoint(int index)
    {
        return EnemyWaypoints[index].transform;
    }

    public Enemy GetEnemy(EnemyType type)
    {
        var data = GetEnemyData(type);

        foreach (var enemy in data.list)
        {
            if (!enemy.gameObject.activeSelf)
            {
                enemy.gameObject.SetActive(true);
                return enemy;
            }
        }

        return InstantiateEnemy(data.prefab, data.list, true);
    }

    public void SpawnEnemy(EnemyType type)
    {
        var enemy = GetEnemy(type);
        if (enemy.Movement.enemyFlies)
        {
            enemy.transform.position = FlyingEnemiesSpawnPosition.position;
        } else
        {
            enemy.transform.position = GroundEnemiesSpawnPosition.position;
        }
    }

    private Enemy InstantiateEnemy(GameObject prefab, List<Enemy> list, bool active = false)
    {
        var enemyInstance = Instantiate(prefab, enemyHolder);
        enemyInstance.SetActive(active);
        var enemy = enemyInstance.GetComponent<Enemy>();
        list.Add(enemy);
        return enemy;
    }

    private EnemyData GetEnemyData(EnemyType type)
    {
        foreach (var data in enemies)
        {
            if (data.type == type)
            {
                return data;
            }
        }

        return null;
    }

    
}
