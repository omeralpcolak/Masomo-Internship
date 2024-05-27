using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Level Config", menuName ="LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public string text;
    public Sprite sprite;
    public Sprite selectedSprite;
    public bool isLevelCompleted
    {
        get => PlayerPrefs.GetInt("IsLevelCompleted", 0) == 1;
        set => PlayerPrefs.SetInt("IsLevelCompleted", value ? 1 : 0);
    }
}
