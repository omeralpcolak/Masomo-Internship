using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;

public enum SceneType
{
    TITLE,
    SELECTLEVEL,
    GAME,
}

public class SceneController : MonoBehaviour
{
    public CanvasGroup fadeScreen;
    protected AudioSource audioSource;
    public AudioClip music;
    public float volume;

    [SerializeField]protected float fadeDuration = 2f;


    public void SetUpComponents(SceneController _sceneController)
    {
        if (audioSource == null)
        {
            audioSource = _sceneController.gameObject.AddComponent<AudioSource>();
        }
        audioSource = _sceneController.GetComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.volume = 0;
        audioSource.playOnAwake = true;
        audioSource.loop = true;
    }

    protected void OnSceneLoad()
    {
        audioSource.Play();
        audioSource.DOFade(volume, fadeDuration).OnStart(() =>
        {
            fadeScreen.DOFade(0, fadeDuration).OnStart(() => DuringFadeIn());
        });
    }

    protected void OnSceneChange(SceneType sceneType)
    {
        fadeScreen.DOFade(1, fadeDuration).OnStart(() =>
        {
            DuringFadeOut();
            audioSource.DOFade(0, fadeDuration).OnComplete(() => ChangeScene(sceneType));
        });
    }


    protected void ChangeScene(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.SELECTLEVEL:
                SceneManager.LoadScene("SelectLevelScene");
                break;
            case SceneType.TITLE:
                SceneManager.LoadScene("TitleScene");
                break;
            case SceneType.GAME:
                SceneManager.LoadScene("GameScene");
                break;
        }
    }

    protected virtual void DuringFadeIn() { }
    protected virtual void DuringFadeOut() { }
}
