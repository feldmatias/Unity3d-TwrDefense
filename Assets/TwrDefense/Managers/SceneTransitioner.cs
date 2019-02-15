using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitioner : MonoBehaviour
{

    public Image image;
    public Color color;
    public float fadeInSpeed = 1;
    public float fadeOutSpeed = 0.5f;

    public static SceneTransitioner Instance;

    private void Awake()
    {
        Instance = this;
        StartCoroutine(FadeOut());
    }

    public void TransitionToScene(string scene)
    {
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

    IEnumerator FadeIn(string scene)
    {
        float timer = 0;

        while (timer <= 1)
        {
            color.a = timer;
            timer += Time.deltaTime * fadeInSpeed;
            image.color = color;
            yield return 0; //Wait one frame
        }

        SceneManager.LoadScene(scene);
    }

    IEnumerator FadeOut()
    {
        float timer = 1;

        while (timer > 0)
        {
            color.a = timer;
            timer -= Time.deltaTime * fadeOutSpeed;
            image.color = color;
            yield return 0; //Wait one frame
        }

        color.a = 0;
        image.color = color;
    }
}
