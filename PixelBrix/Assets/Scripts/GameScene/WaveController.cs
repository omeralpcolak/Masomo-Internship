using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using System.Linq;
public class WaveController : MonoBehaviour
{
    public int hp;
    public List<Brick> bricks;
    public static Action OnWaveAnimEnd;

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
            for(int i =0; i< bricks.Count; i++)
            {
                Brick brick = bricks[i];
                if(brick == bricks.Last())
                {
                    brick.transform.DOMoveY(brick.finalPos.y, 1f).OnComplete(() => OnWaveAnimEnd());
                }
                else
                {
                    brick.transform.DOMoveY(brick.finalPos.y, 1f);
                }

                yield return new WaitForSeconds(0.2f);
            }
        }
        
    }

    

}
