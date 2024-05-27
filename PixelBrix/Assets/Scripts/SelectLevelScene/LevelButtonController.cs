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
    [HideInInspector] public LevelButtonPanel owner;

    public void SetUpConfig(LevelButtonPanel _owner)
    {
        //Scale
        transform.localScale = Vector3.zero;  

        //Owner panel is attached.
        owner = _owner; 

        //Getting Components
        levelButton = GetComponent<Button>();
        levelText = GetComponentInChildren<TMP_Text>();

        //Setting up the configs
        levelText.transform.localScale = Vector3.zero;
        levelText.text = levelConfig.text;
        levelButton.image.sprite = levelConfig.sprite;
        SpriteState spriteState = levelButton.spriteState;
        spriteState.selectedSprite = levelConfig.selectedSprite;
        levelButton.spriteState = spriteState;
    }

    public void InsAnim()
    {
        
        transform.DOScale(1.5f, scaleUpDuration).OnComplete(() => levelText.transform.DOScale(1f, scaleUpDuration));
    }

    public void OnClick()
    {

    }
}
