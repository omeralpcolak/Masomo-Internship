using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutipleBall : Powerup
{
    public GameObject ballClone;
    public int amount;

    public override void ActivatePowerup()
    {
        BallController mainBall = FindAnyObjectByType<BallController>();
        CreateBallClones(amount, mainBall.transform);
    }

    public void CreateBallClones(int amount,Transform mainBallTransform)
    {
        for(int i = 0; i < amount;i ++)
        {
            Instantiate(ballClone, mainBallTransform.position, Quaternion.identity);
        }
    }
}
