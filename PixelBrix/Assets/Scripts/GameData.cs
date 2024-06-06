using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData : MonoBehaviour
{
    public static int Coin
    {
        get => PlayerPrefs.GetInt("Coin", 1);
        set => PlayerPrefs.SetInt("Coin", value);
    }

    public  static LevelConfig selectedLevel;
}
