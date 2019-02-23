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
    private AudioSource audioSource;

    public int difficultyParameter = 20;
    public float nextWaveTime = 15;
    public int maxEnemies = 70;
    public TextAsset normalWavesJson;
    public TextAsset infiniteWavesJson;

    private Wave[] normalWaves;
    private Wave[] infiniteWaves;

    public int CurrentWave { get { return waveIndex + 1; } }
    public float NextWaveTimer { get; private set; }
    public float Difficulty { get; private set; }

    private int waveIndex;
    private Wave currentWave;

    private void Awake()
    {
        Instance = this;
        waveIndex = -1;
        NextWaveTimer = nextWaveTime;
        audioSource = GetComponent<AudioSource>();

        normalWaves = JsonUtility.FromJson<WaveList>(normalWavesJson.text).waves;
        infiniteWaves = JsonUtility.FromJson<WaveList>(infiniteWavesJson.text).waves;
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
        if (EnemyManager.Instance.GetActiveEnemyCount() > maxEnemies)
        {
            return;
        }

        waveIndex ++;
        if (waveIndex < normalWaves.Length)
        {
            currentWave = normalWaves[waveIndex];
        } else
        {
            currentWave = infiniteWaves[Random.Range(0, infiniteWaves.Length)];
        }

        Difficulty = CurrentWave <= difficultyParameter ? 1 : CurrentWave / (float)difficultyParameter;
        currentWave.StartWave();
        audioSource.Play();
    }
}
