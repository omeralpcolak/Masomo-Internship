using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SelectLevelSceneController : SceneController
{
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
        yield return new WaitForSeconds(1f);
        for(int i = 0; i < levelButtons.Count; i++)
        {
            Instantiate(levelButtons[i], levelContent.transform);
            yield return levelButtons[i].scaleUpDuration;
        }
        //levelButtons.ForEach(x => x.levelButton.interactable = true);
    }


}
