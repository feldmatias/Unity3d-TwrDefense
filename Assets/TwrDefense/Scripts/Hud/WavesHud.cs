using UnityEngine;
using UnityEngine.UI;

public class WavesHud : MonoBehaviour
{

    public Text waveNumber;
    public Text nextWaveTimer;
    public GameObject nextWave;

    // Update is called once per frame
    void Update()
    {
        waveNumber.text = WaveManager.Instance.CurrentWave.ToString();

        var nextWaveTime = WaveManager.Instance.NextWaveTimer;

        nextWave.SetActive(nextWaveTime < WaveManager.Instance.nextWaveTime);
        nextWaveTimer.text = Mathf.CeilToInt(nextWaveTime).ToString();
    }
}
