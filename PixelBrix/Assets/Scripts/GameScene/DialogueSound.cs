using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSound : MonoBehaviour
{
    public AudioClip dialogueSoundEffect;
    private AudioSource audioSource;

    private void OnEnable()
    {
        TextAnim.OnDialogue += PlayOrStopTheSound;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = dialogueSoundEffect;
    }

    private void PlayOrStopTheSound(bool _bool)
    {
        if (_bool) { audioSource.Play(); }
        else { audioSource.Stop(); }
    }
}
