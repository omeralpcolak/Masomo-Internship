using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance;
    public List<AudioClip> clips;
    public int sourcesPerClip = 3;

    private Dictionary<string, List<AudioSource>> audioSourcePools;

    private void Awake()
    {
        instance = this;

        audioSourcePools = new Dictionary<string, List<AudioSource>>();

        foreach (AudioClip clip in clips)
        {
            List<AudioSource> audioSources = new List<AudioSource>();
            for (int i = 0; i < sourcesPerClip; i++)
            {
                AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
                newAudioSource.clip = clip;
                newAudioSource.playOnAwake = false;
                newAudioSource.loop = false;
                audioSources.Add(newAudioSource);
            }
            audioSourcePools[clip.name] = audioSources;
        }
    }

    public void PlaySoundEffect(string clipName, float volume)
    {
        if (audioSourcePools.ContainsKey(clipName))
        {
            AudioSource audioSource = GetAvailableAudioSource(audioSourcePools[clipName]);
            if (audioSource != null)
            {
                audioSource.volume = volume;
                audioSource.Play();
            }
            else
            {
                Debug.Log("No available audio source for clip: " + clipName);
            }
        }
        else
        {
            Debug.Log("Sound effect is not found: " + clipName);
        }
    }

    private AudioSource GetAvailableAudioSource(List<AudioSource> audioSources)
    {
        foreach (AudioSource source in audioSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }
        return null;
    }
}
