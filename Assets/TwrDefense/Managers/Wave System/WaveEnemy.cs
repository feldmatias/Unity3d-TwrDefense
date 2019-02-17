using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class WaveEnemy
{
    public EnemyType enemyType;

    public int count;
    private int currentCount;

    public float startSpawnTime;
    public float minNextSpawnTime;
    public float maxNextSpawnTime;
    private float nextSpawnTime;
    private float timer;

    public bool IsFinished { get { return currentCount <= 0; } }

    public void Start()
    {
        currentCount = count;
        nextSpawnTime = startSpawnTime;
        timer = 0;
    }

    public void Spawn()
    {
        if (currentCount <= 0)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= nextSpawnTime)
        {
            timer = 0;
            nextSpawnTime = Random.Range(minNextSpawnTime, maxNextSpawnTime);
            currentCount --;

            EnemyManager.Instance.SpawnEnemy(enemyType);

        }
    }
}
