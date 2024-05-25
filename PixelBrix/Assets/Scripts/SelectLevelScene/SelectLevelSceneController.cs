using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SelectLevelSceneController : SceneController
{
    public List<LevelConfig> levelConfigs;
    public Transform levelContent;
    public List<LevelButtonController> levelButtons;

    private void Start()
    {
        SetUpComponents(this);
        OnSceneLoad();
    }


    protected override void FadeIn()
    {
        StartCoroutine(CreateLevelButtons());
    }

    private IEnumerator CreateLevelButtons()
    {
        List<LevelButtonController> createdLevelButtons = new List<LevelButtonController>();
        yield return new WaitForSeconds(1f);
        for(int i = 0; i < levelButtons.Count; i++)
        {
            LevelButtonController levelButtonIns =Instantiate(levelButtons[i], levelContent.transform);
            levelButtonIns.levelConfig = levelConfigs[i];
            createdLevelButtons.Add(levelButtonIns);
            yield return levelButtons[i].scaleUpDuration;
        }
        createdLevelButtons.ForEach(x => x.levelButton.interactable = true);
    }


}
