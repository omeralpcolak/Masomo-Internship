using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    public TMP_Text titleTxt, playTxt;
    public Button playButton;

    private void Start()
    {
        titleTxt.transform.DOScale(1, 1f).OnComplete(() =>
        {
            playTxt.transform.DOScale(1, 1).OnComplete(() =>
            {
                playButton.interactable = true;
            });
        });
    }


    public void OnClickPlayButton()
    {
        ScenesController.ChangeScene(Scenes.SELECTLEVEL);
    }
}
