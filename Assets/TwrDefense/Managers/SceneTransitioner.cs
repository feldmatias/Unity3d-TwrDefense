﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitioner : MonoBehaviour
{

    public CanvasGroup canvas;
    public float fadeInSpeed = 1;
    public float fadeOutSpeed = 0.5f;

    public static string lastScene;

    public static SceneTransitioner Instance;

    private void Awake()
    {
        Instance = this;
        StartCoroutine(FadeOut());
    }

    public void TransitionToScene(string scene)
    {
        lastScene = scene;
        MusicManager.Instance.SetMenuMusic();
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
        StartCoroutine(FadeIn(scene));
    }

    public void TransitionToMenu()
    {
        TransitionToScene(Scenes.MENU);
    }

    public void TransitionToLevel(int level)
    {
        TransitionToScene(Scenes.Level(level));
    }

    public void RestartLevel()
    {
        TransitionToScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator FadeIn(string scene)
    {
        float timer = 0;

        while (timer <= 1)
        {
            canvas.alpha = timer;
            timer += Time.deltaTime * fadeInSpeed;
            yield return 0; //Wait one frame
        }

        SceneManager.LoadScene(scene);
    }

    IEnumerator FadeOut()
    {
        float timer = string.IsNullOrEmpty(lastScene) ? 0 : 1;

        while (timer > 0)
        {
            canvas.alpha = timer;
            timer -= Time.deltaTime * fadeOutSpeed;
            yield return 0; //Wait one frame
        }

        canvas.alpha = 0;
    }
}
