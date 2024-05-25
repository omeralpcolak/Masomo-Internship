using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LevelButtonController : MonoBehaviour
{
    public LevelConfig levelConfig;
    [HideInInspector] public Button levelButton;
    [HideInInspector] public float scaleUpDuration = 1f;
    private TMP_Text levelText;
    
    void Start()
    {
        levelButton = GetComponent<Button>();
        levelText = GetComponentInChildren<TMP_Text>();
        transform.localScale = Vector3.zero;
        levelText.transform.localScale = Vector3.zero;
        SetUpConfig();
        transform.DOScale(1, scaleUpDuration).OnComplete(() => levelText.transform.DOScale(1, scaleUpDuration));
    }

    private void SetUpConfig()
    {
        levelButton.GetComponentInChildren<TMP_Text>().text = levelConfig.text;
        levelButton.image.sprite = levelConfig.sprite;
    }
}
