using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private GameObject hudCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject gameOverCanvas;

    private bool isPaused = false;
    private bool gameOver = false;

    void Awake()
    {
        Instance = this;
        hudCanvas = GameObject.FindGameObjectWithTag(Tags.HUD_CANVAS);

        gameOverCanvas.SetActive(false);

        ResumeGame();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;

        if (gameOver)
        {
            return;
        }

        hudCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;

        if (gameOver)
        {
            return;
        }

        hudCanvas.SetActive(true);
        pauseMenuCanvas.SetActive(false);
    }

    public void TogglePause()
    {
        if (gameOver)
        {
            return;
        }

        if (isPaused)
        {
            ResumeGame();
        } else
        {
            PauseGame();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        PauseGame();
        gameOverCanvas.SetActive(true);
        hudCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(false);
    }

}
