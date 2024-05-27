using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelButtonPanel : MonoBehaviour
{
    public List<LevelConfig> levelConfigs;
    public LevelButtonController levelButtonController;
    public List<LevelButtonController> createdLevelButtons;
    public static Action OnActivateLevelButtons;

    private void Start()
    {
        SelectLevelSceneController.OnFadeIn += ActivateButtons;
        CreateLevelButtons();
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

    public void ActivateButtons()
    {
        StartCoroutine(ActivateRtn());

        IEnumerator ActivateRtn()
        {
            for(int i = 0; i< createdLevelButtons.Count; i++)
            {
                createdLevelButtons[i].gameObject.SetActive(true);
                createdLevelButtons[i].InsAnim();
                yield return new WaitForSeconds(createdLevelButtons[i].scaleUpDuration);
            }
            yield return new WaitForSeconds(.5f);
            createdLevelButtons.ForEach(x => x.levelButton.interactable = true);
            OnActivateLevelButtons();
        }
    }

}
