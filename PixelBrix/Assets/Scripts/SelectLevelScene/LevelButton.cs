using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LevelButtonController : MonoBehaviour
{
    public string levelName;
    public Sprite levelSprite;
    [HideInInspector] public Button levelButton;
    [HideInInspector] public float scaleUpDuration = 1f;
    
    void Start()
    {
        levelButton = GetComponent<Button>();
        levelButton.GetComponentInChildren<TMP_Text>().text = levelName;
        levelButton.image.sprite = levelSprite;
        transform.DOScale(1, scaleUpDuration);
    }
}
