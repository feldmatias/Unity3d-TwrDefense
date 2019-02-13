using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags
{
    public const string ENEMY_WAYPOINT = "Enemy Waypoint";
}

public class LayerMasks
{
    public const int GROUND_ENEMY = 1 << 9;
    public const int FLYING_ENEMY = 1 << 10;
}

public class EnemyAnimator
{
    public const string DEAD_TRIGGER = "Dead";
    public const string RESET_TRIGGER = "Reset";
}
