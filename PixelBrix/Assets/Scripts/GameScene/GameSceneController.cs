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
    private static List<string> initialDialogueStarted = new();
    public static void SetInitialLevelStart(string name)
    {
        if (initialDialogueStarted.Contains(name) == false)
        {
            initialDialogueStarted.Add(name);
        }
    }
    public static bool CheckLevelContains(string name) => initialDialogueStarted.Contains(name);

    public LevelConfig characterLevel;

    public Image characterImg;
    public TMP_Text dialogueTxt;
    public GameObject dialoguePanel;
    public Button startButton;
    public PaddleController paddlePrefab;
    private PaddleController paddle;
    public GameObject levelCompletePanel;


    void Start()
    {
        SetUpComponents(this);
        OnSceneLoad();
        characterLevel = GameData.selectedLevel;
        paddle = Instantiate(paddlePrefab, paddlePrefab.transform.position, Quaternion.identity);
        paddle.gameObject.SetActive(false);
        Instantiate(characterLevel.levelManager);
        
        TextAnim.OnDialogue += ActivateOrDisableStartButton;
        LevelManager.OnLevelComplete += LoseOrWin;
    }

    private void OnDestroy()
    {
        TextAnim.OnDialogue -= ActivateOrDisableStartButton;
        LevelManager.OnLevelComplete -= LoseOrWin;
    }

    protected override void DuringFadeIn()
    {
        ActivateDialoguePanel(DialogueStyle.INITIAL);
    }

    protected override void DuringFadeOut()
    {
        
    }




    private void LoseOrWin(bool _bool)
    {
        levelCompletePanel.gameObject.SetActive(true);
        TMP_Text levelCompleteText = levelCompletePanel.GetComponentInChildren<TMP_Text>();
        if (_bool)
        {
            ActivateDialoguePanel(DialogueStyle.DEFEATED);
            levelCompleteText.color = Color.green;
            levelCompleteText.text = "VICTORY";
            
        }
        else
        {
            ActivateDialoguePanel(DialogueStyle.WIN);
            levelCompleteText.color = Color.red;
            levelCompleteText.text = "DEFEAT";
        }

        levelCompleteText.GetComponent<TextAnim>().SetTheText();

    }

    public void ActivateDialoguePanel(DialogueStyle style)
    {
        switch (style)
        {
            case DialogueStyle.INITIAL:
                //if(CheckLevelContains())
                characterImg.sprite = characterLevel.idleSprite;
                dialogueTxt.text = characterLevel.dialogues[0];
                break;
            case DialogueStyle.WIN:
                characterImg.sprite = characterLevel.evilSprite;
                dialogueTxt.text = characterLevel.dialogues[1];
                startButton.onClick.RemoveAllListeners();
                startButton.onClick.AddListener(() => OnSceneChange(SceneType.SELECTLEVEL));
                break;
            case DialogueStyle.DEFEATED:
                characterImg.sprite = characterLevel.angrySprite;
                dialogueTxt.text = characterLevel.dialogues[2];
                //characterLevel.isLevelCompleted = true;
                startButton.onClick.RemoveAllListeners();
                startButton.onClick.AddListener(() => OnSceneChange(SceneType.SELECTLEVEL));
                break;
        }

        dialoguePanel.gameObject.SetActive(true);
        dialoguePanel.GetComponent<CanvasGroup>().DOFade(1, 1f).OnComplete(() =>
        {

            dialogueTxt.gameObject.SetActive(true);
            dialogueTxt.GetComponent<TextAnim>().SetTheText();
        });
        

    }


    public void DeactivateDialoguePanel()
    {
        dialoguePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(() =>
        {
            dialogueTxt.gameObject.SetActive(false);
            dialoguePanel.gameObject.SetActive(false);
        });
        audioSource.volume = 0.2f;
    }


    private void ActivateOrDisableStartButton(bool _bool)
    {
        if (_bool) { startButton.gameObject.SetActive(false); }
        else { startButton.gameObject.SetActive(true); }
    }

    public void OnStartButtonClick()
    {
        LevelManager.isLevelStart = true;
        DeactivateDialoguePanel();
        paddle.gameObject.SetActive(true);
    }
    
}
