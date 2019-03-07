using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectedDifficulty
{

    private static readonly Dictionary<string, int> difficulties = new Dictionary<string, int>
    {
        { "Easy", 20 },
        { "Normal", 15 },
        { "Hard", 10 }
    };

    private static string selectedDifficulty = "Normal";

    public static List<string> GetOptions()
    {
        return difficulties.Keys.ToList();
    }

    public static void SetDifficulty(string option)
    {
        selectedDifficulty = option;
    }

    public static string GetDifficultyOption()
    {
        return selectedDifficulty;
    }

    public static int GetDifficulty()
    {
        return difficulties[selectedDifficulty];
    }
}
