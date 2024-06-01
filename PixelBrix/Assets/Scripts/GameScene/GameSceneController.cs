using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public enum DialogueStyle
{
    INITIAL,
    WIN,
    DEFEATED,
}

public class GameSceneController : SceneController
{
    public GameManager manager;
    public LevelConfig characterLevel;

    public Image characterImg;
    public TMP_Text dialogueTxt;
    public GameObject dialoguePanel;

    void Start()
    {
        SetUpComponents(this);
        OnSceneLoad();
        characterLevel = manager.selectedLevel;
        WaveController.OnWaveAnimEnd += DeactivateDialoguePanel;
    }

    protected override void FadeIn()
    {
        ActivateDialoguePanel(DialogueStyle.INITIAL);
    }

    protected override void FadeOut()
    {
        OnSceneChange(SceneType.SELECTLEVEL);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateDialoguePanel(DialogueStyle.WIN);
        }
    }

    public void ActivateDialoguePanel(DialogueStyle style)
    {
        switch (style)
        {
            case DialogueStyle.INITIAL:
                characterImg.sprite = characterLevel.idleSprite;
                dialogueTxt.text = characterLevel.dialogues[0];
                break;
            case DialogueStyle.WIN:
                characterImg.sprite = characterLevel.evilSprite;
                dialogueTxt.text = characterLevel.dialogues[1];
                break;
            case DialogueStyle.DEFEATED:
                characterImg.sprite = characterLevel.angrySprite;
                dialogueTxt.text = characterLevel.dialogues[2];
                break;
        }
        dialoguePanel.gameObject.SetActive(true);
        dialoguePanel.GetComponent<CanvasGroup>().DOFade(1, 1f).OnComplete(() =>
        {
            
            dialogueTxt.gameObject.SetActive(true);
        });
        
    }


    public void DeactivateDialoguePanel()
    {
        dialoguePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(() =>
        {
            dialogueTxt.gameObject.SetActive(false);
            dialoguePanel.gameObject.SetActive(false);
        });
        
    }

    
}
