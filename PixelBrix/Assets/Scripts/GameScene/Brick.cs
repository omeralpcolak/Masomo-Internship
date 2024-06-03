using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Brick : MonoBehaviour
{
    [HideInInspector]public WaveController owner;
    public Vector3 finalPos;
    private BoxCollider2D col;

    public void Init(WaveController _owner)
    {
        gameObject.SetActive(true);
        col = GetComponent<BoxCollider2D>();
        owner = _owner;
        owner.hp += 1;
        transform.parent = null;
        finalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.parent = owner.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            col.enabled = false;
            FindAnyObjectByType<LevelManager>().CheckEligiableForNextLevel(owner.hp);
            //InsantiateEffect;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        owner.hp -= 1;
        Debug.Log(name + " " + owner.hp);
    }



}
