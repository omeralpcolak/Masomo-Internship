using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultipleBall : Powerup
{
    public GameObject ballClone;
    public int amount;
    public List<GameObject> ballClones;

    public override void ActivatePowerup()
    {
        PaddleController paddle = FindAnyObjectByType<PaddleController>();
        CreateBallClones(amount, paddle.transform);
    }

    public void CreateBallClones(int amount,Transform paddleTransform)
    {
        for(int i = 0; i < amount;i ++)
        {
            GameObject ballCloneIns = Instantiate(ballClone, paddleTransform.position, Quaternion.identity);
            ballClones.Add(ballCloneIns);
            Rigidbody2D ballCloneRb = ballCloneIns.GetComponent<Rigidbody2D>();
            ballCloneRb.velocity = new Vector2(Random.Range(-5, 5), 10);

        }
    }

    public override void DeactivatePowerUp()
    {
        ballClones.ForEach(x => Destroy(x.gameObject));
        Destroy(gameObject);
    }
}
