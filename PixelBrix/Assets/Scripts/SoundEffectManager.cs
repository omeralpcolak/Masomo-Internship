using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance;
    private AudioSource audioSource;
    public List<AudioClip> clips;



    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }


    public void PlaySoundEffect(string clipName, float volume)
    {
        audioSource.Stop();
        audioSource.clip = null;
        AudioClip soundEffect = clips.Find(c => c.name == clipName);
        if(soundEffect != null)
        {
            audioSource.clip = soundEffect;
            audioSource.volume = volume;
            audioSource.Play();
        }
        else
        {
            Debug.Log("Sound effect is not found!");
        }
    }
}
