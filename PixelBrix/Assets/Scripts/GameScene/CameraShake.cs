using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    private Vector3 initialPos;
    [SerializeField] private float duration;
    [SerializeField] private float strength = 0.3f;
    [SerializeField] private int vibrato = 10;
    [SerializeField] private float randomness = 90f;
    private bool canShake = true;

    private void Awake()
    {
        instance = this;
        initialPos = transform.position;
    }


    public void Shake()
    {
        if (canShake)
        {
            canShake = false;
            transform.DOShakePosition(duration, strength, vibrato, randomness).OnComplete(() =>
            {
                canShake = true;
                transform.position = initialPos;
            });
        }
        
    }
}
