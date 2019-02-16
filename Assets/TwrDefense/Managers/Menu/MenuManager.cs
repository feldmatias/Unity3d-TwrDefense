using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneTransitioner.Instance.TransitionToScene(Scenes.LEVEL_SELECT);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Back button
            Exit();
        }
    }
}
