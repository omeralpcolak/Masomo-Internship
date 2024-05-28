using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Game Manager", menuName ="Game Manager")]
public class GameManager : ScriptableObject
{
    public static int Coin
    {
        get => PlayerPrefs.GetInt("Coin", 1);
        set => PlayerPrefs.SetInt("Coin", value);
    }

    public  LevelConfig selectedLevel;
}
