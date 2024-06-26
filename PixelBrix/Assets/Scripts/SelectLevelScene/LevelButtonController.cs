using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LevelButtonController : MonoBehaviour
{
    public LevelConfig levelConfig;
    [HideInInspector] public float scaleUpDuration = 1f;
    [HideInInspector] public Button button;
    [HideInInspector] public LevelButtonPanel owner;
    private TMP_Text levelText;
    public Image locked;
    public bool selected;


    public void SetUpConfig(LevelButtonPanel _owner)
    {
        transform.localScale = Vector3.zero;  
        owner = _owner; 
        button = GetComponent<Button>();
        levelText = GetComponentInChildren<TMP_Text>();
        levelText.text = levelConfig.text;
        levelText.gameObject.SetActive(false);
        button.image.sprite = levelConfig.idleSprite;
    }

    public void CheckInteractable()
    {
        button.interactable = levelConfig.isItFirstLevel || levelConfig.isLevelCompleted ? true : false;
        if (!button.interactable) { locked.gameObject.SetActive(true); }
    }

    public void InsAnim()
    {
        transform.DOScale(1.5f, scaleUpDuration).OnComplete(() =>
        {
            levelText.gameObject.SetActive(true);
            levelText.GetComponent<TextAnim>().SetTheText();
        });
    }

    public void OnButtonSelected()
    {
        selected = true;
        SoundEffectManager.instance.PlaySoundEffect("buttonSound", 0.2f);
        button.image.sprite = levelConfig.evilSprite;
        Animator textAnim = levelText.GetComponent<Animator>();
        textAnim.SetBool("isSelected", true);
        GameData.selectedLevel = levelConfig;
        owner.CheckSelectedStateOfButtons(this);
    }

    public void OnButtonDeselected()
    {
        selected = false;
        button.image.sprite = levelConfig.idleSprite;
        Animator textAnim = levelText.GetComponent<Animator>();
        textAnim.SetBool("isSelected", false);
    }

   
}
