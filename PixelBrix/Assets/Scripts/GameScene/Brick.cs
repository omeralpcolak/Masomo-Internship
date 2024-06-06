using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Brick : MonoBehaviour
{
    [HideInInspector]public WaveController owner;
    public Vector3 finalPos;
    private BoxCollider2D col;
    public List<Sprite> sprites;
    private int index;
    public Sprite currentSprite => sprites[index];
    private SpriteRenderer spRenderer;
    private int hitCount = 0;

    public void Init(WaveController _owner)
    {
        gameObject.SetActive(true);
        spRenderer = GetComponentInChildren<SpriteRenderer>();
        SetSprite();
        col = GetComponent<BoxCollider2D>();
        owner = _owner;
        owner.hp += 1;
        transform.parent = null;
        finalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.parent = owner.transform;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            owner.ShakeTheBricks();
            hitCount++;
            if (hitCount >= sprites.Count)
            {
                col.enabled = false;
                owner.hp -= 1;
                FindAnyObjectByType<LevelManager>().CheckEligiableForNextLevel(owner.hp);
                //InsantiateEffect;
                Destroy(gameObject);
            }
            else
            {
                index++;
                SetSprite();
            }
        }
    }

    private void SetSprite()
    {
        spRenderer.sprite = currentSprite;
    }

    private void OnDestroy()
    {
        Debug.Log(name + " " + owner.hp);
    }



}
