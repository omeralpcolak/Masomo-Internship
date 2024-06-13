using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    
    private void Start()
    {
        LevelManager.OnNextWave += DeactivatePowerUp;
        LevelManager.OnLevelComplete += DestroyPowerup;
    }


    private void OnDestroy()
    {
        LevelManager.OnNextWave -= DeactivatePowerUp;
        LevelManager.OnLevelComplete -= DestroyPowerup;
    }


    public virtual void ActivatePowerup()
    {

    }

    public virtual void DeactivatePowerUp()
    {

    }

    public virtual void DestroyPowerup(bool _bool)
    {

    }

    
}
