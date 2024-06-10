using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public enum BallPosition
{
    FREE,
    INITIAL
}

public class BallController : MonoBehaviour
{
    public GameObject ballSprite;
    private BallPosition posStatus;
    private bool isballMoving;
    private bool ableToMove;
    private Rigidbody2D rb;
    public PaddleController ownerPaddle;
    public GameObject collisionEffect;
    public float constantVelocity = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ableToMove = true;
    }

    private void OnDestroy()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Border"))
        {
            
            CameraShake.instance.Shake();
        }

       

        if (collision.gameObject.CompareTag("Paddle") && posStatus == BallPosition.FREE)
        {
            SoundEffectManager.instance.PlaySoundEffect("ballHit", 0.2f);
            Instantiate(collisionEffect, collision.contacts[0].point, Quaternion.identity);
        }

        rb.velocity = rb.velocity.normalized * constantVelocity;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BottomBorder"))
        {
            LevelManager.OnLevelComplete?.Invoke(false);
        }
    }
    public void Init(PaddleController _owner)
    {
        ownerPaddle = _owner;
        transform.parent = ownerPaddle.transform;
    }

    public void ApplyForce()
    {
        if (!isballMoving && ableToMove)
        {
            isballMoving = true;
            PositionState(BallPosition.FREE);
            rb.velocity = new Vector2(UnityEngine.Random.Range(-5, 5), 10);
        }
    }

    public void PositionState(BallPosition state)
    {
        Debug.Log("Position state is called");
        switch (state)
        {
            case BallPosition.INITIAL:
                posStatus = BallPosition.INITIAL;
                isballMoving = false;
                ableToMove = false;
                rb.velocity = Vector3.zero;
                transform.position = ownerPaddle.transform.position;
                transform.parent = ownerPaddle.transform;
                break;
            case BallPosition.FREE:
                posStatus = BallPosition.FREE;
                transform.parent = null;
                ableToMove = true;
                ApplyForce();
                break;
        }
    }
}
