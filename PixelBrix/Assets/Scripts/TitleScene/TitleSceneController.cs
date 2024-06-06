using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class TitleSceneController : SceneController
{
    public TMP_Text titleTxt, playTxt;
    public Button playButton;

    private void Start()
    {
        SetUpComponents(this);
        OnSceneLoad();
    }


    public void OnClickPlayButton()
    {
        playButton.interactable = false;
        OnSceneChange(SceneType.SELECTLEVEL);
    }


    protected override void DuringFadeIn()
    {
        titleTxt.gameObject.SetActive(true);
        titleTxt.GetComponent<TextAnim>().SetTheText();
        playTxt.transform.DOScale(1, 1f).OnComplete(() => playButton.interactable = true);
    }

    protected override void DuringFadeOut()
    {
        titleTxt.transform.DOScale(0, 1f).OnStart(() =>
        {
            playTxt.transform.DOScale(0, 1f).OnComplete(() => playButton.interactable = false);
        });
    }

}
