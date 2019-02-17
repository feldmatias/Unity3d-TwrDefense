using System;

[Serializable]
public class Wave
{
    public WaveEnemy[] enemies;

    public bool IsFinished { get; private set; }

    public void StartWave()
    {
        IsFinished = false;
        foreach (var enemy in enemies)
        {
            enemy.Start();
        }
    }

    public void Spawn()
    {
        var finished = true;

        foreach (var enemy in enemies)
        {
            enemy.Spawn();
            finished &= enemy.IsFinished;
        }

        IsFinished = finished;
    }
}
