using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    public GameObject buttonPrefab;

    public Color normalColor;
    public Color selectedColor;

    private List<Button> buttons;

    private void Awake()
    {
        buttons = new List<Button>();

        foreach (var option in SelectedDifficulty.GetOptions())
        {
            InitializeButton(option);
        }
    }
    
    private void InitializeButton(string option)
    {
        var button = Instantiate(buttonPrefab, transform).GetComponent<Button>();
        button.GetComponentInChildren<Text>().text = option.ToUpper();

        var color = option == SelectedDifficulty.GetDifficultyOption() ? selectedColor : normalColor;
        SetButtonColor(button, color);

        button.onClick.AddListener(() => SelectOption(button, option));

        buttons.Add(button);
    }

    private void SetButtonColor(Button button, Color color)
    {
        var colors = button.colors;
        colors.normalColor = color;
        colors.highlightedColor = color;
        button.colors = colors;
    }

    private void SelectOption(Button button, string option)
    {
        foreach (var btn in buttons)
        {
            var color = btn == button ? selectedColor : normalColor;
            SetButtonColor(btn, color);
        }

        SelectedDifficulty.SetDifficulty(option);
    }
}
