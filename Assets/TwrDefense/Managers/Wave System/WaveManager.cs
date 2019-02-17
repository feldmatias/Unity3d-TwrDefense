using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class WaveList
{
    public Wave[] waves;
}

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    public float nextWaveTime = 10;
    public TextAsset normalWavesJson;

    private Wave[] normalWaves;
    public Wave[] infiniteWaves;

    public int CurrentWave { get { return waveIndex + 1; } }
    public float NextWaveTimer { get; private set; }

    private int waveIndex;
    private Wave currentWave;

    private void Awake()
    {
        Instance = this;
        waveIndex = -1;
        NextWaveTimer = nextWaveTime;
        
        normalWaves = JsonUtility.FromJson<WaveList>(normalWavesJson.text).waves;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveIndex < 0 || currentWave.IsFinished)
        {
            NextWaveTimer -= Time.deltaTime;
            if (NextWaveTimer <= 0)
            {
                NextWaveTimer = nextWaveTime;
                SelectNextWave();
            }
        } else
        {
            currentWave.Spawn();
        }
    }

    private void SelectNextWave()
    {
        waveIndex ++;
        if (waveIndex < normalWaves.Length)
        {
            currentWave = normalWaves[waveIndex];
        } else
        {
            currentWave = infiniteWaves[Random.Range(0, infiniteWaves.Length)];
        }

        currentWave.StartWave();
    }
}
