﻿using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SelectableLevel
{
    public int level;
    public string name;
    public Sprite image;
}

public class LevelSelectManager : MonoBehaviour
{
    public Image levelImage;
    public Text levelText;

    public SelectableLevel[] levels;

    private int levelIndex = 0;

    private void Start()
    {
        SetLevel();
    }

    private void SetLevel()
    {
        levelImage.sprite = levels[levelIndex].image;
        levelText.text = levels[levelIndex].name;
    }

    public void ChangeLevelLeft()
    {
        levelIndex -= 1;
        if (levelIndex < 0)
        {
            levelIndex = levels.Length - 1;
        }
        SetLevel();
    }

    public void ChangeLevelRight()
    {
        levelIndex += 1;
        if (levelIndex >= levels.Length)
        {
            levelIndex = 0;
        }
        SetLevel();
    }

    public void PlayLevel()
    {
        SceneTransitioner.Instance.TransitionToLevel(levels[levelIndex].level);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Back button
            SceneTransitioner.Instance.TransitionToMenu();
        }
    }

}
