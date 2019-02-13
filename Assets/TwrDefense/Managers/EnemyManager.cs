using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager Instance;

    public static List<GameObject> EnemyWaypoints;

    public static Transform GroundEnemiesSpawnPosition;
    public static Transform FlyingEnemiesSpawnPosition;

    private void Awake()
    {
        Instance = this;

        GroundEnemiesSpawnPosition = GameObject.FindGameObjectWithTag(Tags.GROUND_ENEMY_SPAWN).transform;
        FlyingEnemiesSpawnPosition = GameObject.FindGameObjectWithTag(Tags.FLYING_ENEMY_SPAWN).transform;

        EnemyWaypoints = GameObject.FindGameObjectsWithTag(Tags.ENEMY_WAYPOINT).OrderBy(w => w.name).ToList();
    }

    public int GetLastWaypointIndex()
    {
        return EnemyWaypoints.Count - 1;
    }

    public static Transform GetWaypoint(int index)
    {
        return EnemyWaypoints[index].transform;
    }

    
}
