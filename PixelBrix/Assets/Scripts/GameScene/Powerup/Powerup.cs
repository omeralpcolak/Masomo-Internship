using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    
    private void Start()
    {
        LevelManager.OnNextWave += DeactivatePowerUp;
    }


    private void OnDestroy()
    {
        LevelManager.OnNextWave -= DeactivatePowerUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ActivatePowerup();
        }
    }

    public virtual void ActivatePowerup()
    {

    }

    public virtual void DeactivatePowerUp()
    {

    }
}
