using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Brick : MonoBehaviour
{
    [HideInInspector]public WaveController owner;
    public Vector3 finalPos;
    private BoxCollider2D col;
    public List<GameObject>effects;
    public List<Sprite> sprites;
    private int index;
    public Sprite CurrentSprite => sprites[index];
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
            InstantiateEffects(collision.contacts[0]);
            SoundEffectManager.instance.PlaySoundEffect("ballHit", 0.2f);
            owner.ShakeTheBricks();
            hitCount++;
            if (hitCount >= sprites.Count)
            {
                col.enabled = false;
                owner.hp -= 1;
                FindAnyObjectByType<LevelManager>().CheckEligiableForNextLevel(owner.hp);
                spRenderer.transform.DOMoveY(spRenderer.transform.position.y + 0.2f, 0.15f)
                    .SetEase(Ease.InOutCubic).OnComplete(() => spRenderer.transform.DOScale(0, 0.15f).OnComplete(() => Destroy(gameObject)));
            }
            else
            {
                
                index++;
                SetSprite();
            }
        }
    }

    private void InstantiateEffects(ContactPoint2D contact)
    {
        int randomIndex = Random.Range(0, effects.Count - 1);
        Instantiate(effects[randomIndex], contact.point, Quaternion.identity);
    }

    private void SetSprite()
    {
        spRenderer.sprite = CurrentSprite;
    }

    private void OnDestroy()
    {
        //Debug.Log(name + " " + owner.hp);
    }



}
