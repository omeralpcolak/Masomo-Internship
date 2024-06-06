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
    public static Action<bool> OnWaveCreating;

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
            OnWaveCreating?.Invoke(true);
            for(int i =0; i< bricks.Count; i++)
            {
                Brick brick = bricks[i];
                if(brick != bricks.Last())
                {
                    brick.transform.DOMoveY(brick.finalPos.y, 1f).OnComplete(() => brick.transform.parent = this.transform);
                }
                else
                {
                    brick.transform.DOMoveY(brick.finalPos.y, 1f).OnComplete(() =>
                    {

                        brick.transform.parent = this.transform;
                        OnWaveCreating?.Invoke(false);
                    });
                }
                
                yield return new WaitForSeconds(0.2f);
            }
            //OnWaveCreating?.Invoke(false);
        }
        
    }

    public void ShakeTheBricks()
    {
        Sequence shakeSequence = DOTween.Sequence();
        shakeSequence.Append(transform.DOMoveX(0.1f, 0.1f))
                     .Append(transform.DOMoveX(-0.1f, 0.1f))
                     .Append(transform.DOMoveX(0, 0.1f));
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

}
