using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WaveController : MonoBehaviour
{
    public int hp;
    public List<Brick> bricks;
    public Action OnWaveAnim;

    public void SetUpWave()
    {
        bricks.ForEach(x => x.Init(this));
    }


    public void WaveAnim()
    {
        StartCoroutine(WaveAnimRtn());
        IEnumerator WaveAnimRtn()
        {
            transform.position = new Vector3(0, 10, 0);
            foreach (Brick brick in bricks)
            {
                brick.Move();
                yield return new WaitForSeconds(0.3f);
            }
        }
        
    }
}
