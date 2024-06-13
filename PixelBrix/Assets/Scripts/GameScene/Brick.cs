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
    private int hitCount = 0;

    public Sprite CurrentSprite => sprites[index];
    private SpriteRenderer spRenderer;
    
    public PowerupHolder powerupHolder;
    

    public void Init(WaveController _owner)
    {
        gameObject.SetActive(true);
        spRenderer = GetComponentInChildren<SpriteRenderer>();
        SetSprite();
        col = GetComponent<BoxCollider2D>();
        owner = _owner;
        //owner.hp += 1;
        transform.parent = null;
        finalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.parent = owner.transform;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ball")&& LevelManager.isLevelStart)
        {
            InstantiateEffects(collision.contacts[0]);
            SoundEffectManager.instance.PlaySoundEffect("ballHit", 0.2f);
            owner.ShakeTheBricks();
            hitCount++;
            if (hitCount >= sprites.Count)
            {
                col.enabled = false;
                CreateThePowerUpHolder();
                spRenderer.transform.DOMoveY(spRenderer.transform.position.y + 0.2f, 0.15f)
                    .SetEase(Ease.InOutCubic).OnComplete(() => spRenderer.transform.DOScale(0, 0.15f).OnComplete(() =>
                    {
                        gameObject.SetActive(false);
                    }));
            }
            else
            {   
                index++;
                SetSprite();
            }
        }
    }

    private void CreateThePowerUpHolder()
    {
        int possibility = 100;
        int number = Random.Range(0, 100);
        if(number <= possibility)
        {
            Instantiate(powerupHolder, transform.position, Quaternion.identity);
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

    private void OnDisable()
    {
        owner.CheckHp();

        LevelManager levelManager = FindAnyObjectByType<LevelManager>();
        if(levelManager != null)
        {
            levelManager.CheckEligiableForNextLevel(owner.hp);
        }
        else { return; }
        Debug.Log("Current hp: " + owner.hp);
    }



}
