using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelButtonPanel : MonoBehaviour
{
    public List<LevelConfig> levelConfigs;
    public LevelButtonController levelButtonController;
    public List<LevelButtonController> createdLevelButtons;
    public GameManager gameManager;
    public static Action OnActivateLevelButtons;
    public static Action OnSelectButton;

    private void Start()
    {
        SelectLevelSceneController.OnFadeIn += ActivateLevelButtons;
        SelectLevelSceneController.OnFadeOut += MakeTheButtonsNoInteractable;
        CreateLevelButtons();
    }

    private void OnDestroy()
    {
        Debug.Log(name + "is called OnDestroy");
        SelectLevelSceneController.OnFadeIn -= ActivateLevelButtons;
        SelectLevelSceneController.OnFadeOut -= MakeTheButtonsNoInteractable;
    }

    private void CreateLevelButtons()
    {
        for (int i = 0; i < levelConfigs.Count; i++)
        {
            LevelButtonController levelButtonIns = Instantiate(levelButtonController, transform);
            levelButtonIns.levelConfig = levelConfigs[i];
            levelButtonIns.SetUpConfig(this);
            createdLevelButtons.Add(levelButtonIns);
            levelButtonIns.gameObject.SetActive(false);
        }

        
    }

    public void ActivateLevelButtons()
    {
        StartCoroutine(ActivateRtn());

        IEnumerator ActivateRtn()
        {
            createdLevelButtons.ForEach(x => x.CheckInteractable());
            for (int i = 0; i< createdLevelButtons.Count; i++)
            {
                createdLevelButtons[i].gameObject.SetActive(true);
                createdLevelButtons[i].InsAnim();
                if (i > 0)
                {
                    createdLevelButtons[i].button.interactable = createdLevelButtons[i - 1].levelConfig.isLevelCompleted ? true : false;
                }
                yield return new WaitForSeconds(createdLevelButtons[i].scaleUpDuration);
            }
            
            yield return new WaitForSeconds(.5f);
            OnActivateLevelButtons();
        }
    }

    public void CheckSelectedStateOfButtons(LevelButtonController selectedButton)
    {
        foreach(LevelButtonController button in createdLevelButtons)
        {
            if(button != selectedButton)
            {
                button.OnButtonDeselected();
            }
        }
    }

    public void MakeTheButtonsNoInteractable()
    {
        createdLevelButtons.ForEach(x => x.button.interactable = false);
    }
}
