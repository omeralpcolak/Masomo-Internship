using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Brick : MonoBehaviour
{
    [HideInInspector]public WaveController owner;
    public Vector3 finalPos;

    public void Init(WaveController _owner)
    {
        gameObject.SetActive(false);
        owner = _owner;
        owner.hp += 1;
        transform.parent = null;
        finalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.parent = owner.transform;
        

    }


    public void Move()
    {
        gameObject.SetActive(true);
        transform.parent = null;
        transform.DOMoveY(finalPos.y, 1f)
            .SetEase(Ease.InFlash);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            owner.hp -= 1;
            //InsantiateEffect;
            FindAnyObjectByType<LevelManager>().CheckEligiableForNextLevel(owner.hp);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        
    }



}
