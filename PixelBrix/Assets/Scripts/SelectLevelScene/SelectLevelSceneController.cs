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

    private void Start()
    {
        SetUpComponents(this);
        OnSceneLoad();
        LevelButtonPanel.OnActivateLevelButtons += ActivateMenuButtons;
    }

    private void OnDestroy()
    {
        LevelButtonPanel.OnActivateLevelButtons -= ActivateMenuButtons;

    }


    protected override void DuringFadeIn()
    {
        text.gameObject.SetActive(true);
        text.GetComponent<TextAnim>().SetTheText();
        GameData.selectedLevel = null;
        OnFadeIn();
        
    }

    protected override void DuringFadeOut()
    {
        OnFadeOut();
        playButton.interactable = false;
        quitButton.interactable = false;

    }

    public void OnClickPlayButton()
    {
        if(GameData.selectedLevel != null) { OnSceneChange(SceneType.GAME); }
        
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

    




}
