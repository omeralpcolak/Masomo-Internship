using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
public class SelectLevelSceneController : SceneController
{
    public static Action OnFadeIn;
    public TMP_Text text;
    public Button playButton;

    private void Start()
    {
        SetUpComponents(this);
        OnSceneLoad();
        LevelButtonPanel.OnActivateLevelButtons += ActivatePlayButton;
    }


    protected override void FadeIn()
    {
        text.transform.DOScale(1, 1f).OnComplete(() =>
        {
            OnFadeIn();
        });
        
    }

    public void OnClickPlayButton()
    {

    }

    private void ActivatePlayButton()
    {
        playButton.transform.DOScale(1, 1f).OnComplete(() => playButton.interactable = true);
    }

    


}
