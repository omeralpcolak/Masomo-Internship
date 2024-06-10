using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PaddleController : MonoBehaviour
{
    public ParticleSystem paddleParticle;
    public BallController ball;
    //public bool canMove;

    private void Start()
    {
        ball.Init(this);
        WaveController.OnWaveCreating += HandleBallPosition;
    }

    private void OnDestroy()
    {
        WaveController.OnWaveCreating -= HandleBallPosition;
    }
    void FixedUpdate()
    {  
        if (Input.GetMouseButton(0)&& LevelManager.isLevelStart)
        {
            ball.ApplyForce();
            paddleParticle.gameObject.SetActive(true);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clampPos = new Vector2(Mathf.Clamp(mousePos.x, -10, 10), transform.position.y);


            transform.DOMove(clampPos, 0.1f)
                .SetEase(Ease.Linear);
        }
        else
        {
            paddleParticle.gameObject.SetActive(false);
        }
    }

    private void HandleBallPosition(bool _bool)
    {
        if (_bool)
        {
            ball.PositionState(BallPosition.INITIAL);
        }
        else
        {
            ball.PositionState(BallPosition.FREE);
        }
    }

    


}
