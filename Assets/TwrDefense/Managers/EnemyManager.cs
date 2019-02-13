using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager Instance;

    public static List<GameObject> EnemyWaypoints;

    private void Awake()
    {
        Instance = this;
        EnemyWaypoints = GameObject.FindGameObjectsWithTag(Tags.ENEMY_WAYPOINT).OrderBy(w => w.name).ToList();
    }

    public static Transform GetWaypoint(int index)
    {
        return EnemyWaypoints[index].transform;
    }

    
}
