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
    public static Action OnFadeOut;
    public TMP_Text text;
    public Button playButton;
    public Button quitButton;
    public GameManager gameManager;

    private void Start()
    {
        SetUpComponents(this);
        OnSceneLoad();
        LevelButtonPanel.OnActivateLevelButtons += ActivateMenuButtons;
    }


    protected override void FadeIn()
    {
        text.gameObject.SetActive(true);
        OnFadeIn();
        
    }

    protected override void FadeOut()
    {
        OnFadeOut();
        playButton.interactable = false;
        quitButton.interactable = false;

    }

    public void OnClickPlayButton()
    {
        if(gameManager.selectedLevel != null) { OnSceneChange(SceneType.GAME); }
        
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    private void ActivateMenuButtons()
    {
        playButton.transform.DOScale(1, 1f).OnComplete(() => playButton.interactable = true);
        quitButton.transform.DOScale(1, 1f).OnComplete(() => quitButton.interactable = true);
    }

    private void OnDisable()
    {
        LevelButtonPanel.OnActivateLevelButtons -= ActivateMenuButtons;
    }




}
