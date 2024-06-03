using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

[System.Serializable]
public class Wave
{
    public WaveController wavePrefab;
    public void CreateTheWave(Transform transform)
    {
        WaveController wave = GameObject.Instantiate(wavePrefab, transform.position, Quaternion.identity);
        wave.SetUpWave();
        wave.WaveAnim();
    }
}


public class LevelManager : MonoBehaviour
{
    private int index;
    public List<Wave> waves;
    public Wave CurrentWave => waves[index];

    private void Start()
    {
        index = 0;
        InsTheWave();
    }

    private void InsTheWave()
    {
        CurrentWave.CreateTheWave(transform);
    }

    public void CheckEligiableForNextLevel(int hp)
    {
        if(hp <= 0)
        {
            NextWave();
        }
    }

    public void NextWave()
    {
        index++;
        if(index < waves.Count)
        {
            InsTheWave();
        }
        else
        {
            //Player wins
            //Enemy defated.
        }
    }
}
