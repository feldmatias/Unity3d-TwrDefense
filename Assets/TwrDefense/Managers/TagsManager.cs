using UnityEngine;

public class Tags
{
    public const string ENEMY = "Enemy";
    public const string ENEMY_WAYPOINT = "Enemy Waypoint";
    public const string GROUND_ENEMY_SPAWN = "Ground Enemy Spawn Position";
    public const string FLYING_ENEMY_SPAWN = "Flying Enemy Spawn Position";
    public const string HUD_CANVAS = "HUD";
}

public class Layers
{
    public const string GROUND_ENEMY = "Ground Enemy";
    public const string FLYING_ENEMY = "Flying Enemy";
    public const string TOWER_GROUND = "Tower Ground";

    public static int GetLayerMask(string layer)
    {
        return 1 << LayerMask.NameToLayer(layer);
    }
}

public class EnemyAnimator
{
    public const string DEAD_TRIGGER = "Dead";
    public const string RESET_TRIGGER = "Reset";
    public const string EFFECT = "Effect";
}

public class Scenes
{
    public const string MENU = "Menu";
    public const string LEVEL_SELECT = "Level Select";

    private const string LEVEL = "Level{0:D2}";

    public static string Level(int level)
    {
        return string.Format(LEVEL, level);
    }
}
