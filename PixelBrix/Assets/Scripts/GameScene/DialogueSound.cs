using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DialogueSound : MonoBehaviour
{
    public AudioClip dialogueSoundEffect;
    private AudioSource audioSource;

    private void Awake()
    {
        TextAnim.OnDialogue += PlayOrStopTheSound;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = dialogueSoundEffect;
    }

    private void OnDestroy()
    {
        TextAnim.OnDialogue -= PlayOrStopTheSound;
    }

    private void PlayOrStopTheSound(bool _bool)
    {
        if (_bool)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
