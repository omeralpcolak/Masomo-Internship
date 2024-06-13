using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHolder : MonoBehaviour
{
    public List<Powerup> powerups;
    public GameObject collisionEffect;
    private Powerup powerupIns;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            SoundEffectManager.instance.PlaySoundEffect("powerUp", 0.2f);
            Instantiate(collisionEffect, collision.gameObject.transform);
            powerupIns = Instantiate(powerups[Random.Range(0,powerups.Count-1)], transform.position, Quaternion.identity);
            powerupIns.ActivatePowerup();
            Destroy(gameObject);
        }
    }

}
