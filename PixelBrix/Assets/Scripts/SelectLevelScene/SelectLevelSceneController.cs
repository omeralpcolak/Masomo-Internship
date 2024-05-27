using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class SelectLevelSceneController : SceneController
{
    public static Action OnFadeIn;

    private void Start()
    {
        SetUpComponents(this);
        OnSceneLoad();
    }


    protected override void FadeIn()
    {
        OnFadeIn();
    }

    


}
