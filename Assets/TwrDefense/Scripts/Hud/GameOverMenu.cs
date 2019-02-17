using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Text wavesResult;

    const string wavesResultMessage = "You survived {0} waves";

    private void OnEnable()
    {
        var waves = WaveManager.Instance.CurrentWave - 1;
        wavesResult.text = string.Format(wavesResultMessage, waves);
    }
}
