using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scenes
{
    TITLE,
    SELECTLEVEL,
    GAME,
}

public class ScenesController
{
    public Scenes scenes;

    public static void ChangeScene(Scenes scenes)
    {
        switch (scenes)
        {
            case Scenes.TITLE:
                SceneManager.LoadScene("TitleScene");
                break;
            case Scenes.SELECTLEVEL:
                SceneManager.LoadScene("SelectLevelScene");
                break;
            case Scenes.GAME:
                SceneManager.LoadScene("GameScene");
                break;


        }
    }
}
