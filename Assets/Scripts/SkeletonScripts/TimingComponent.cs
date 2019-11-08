using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingComponent : MonoBehaviour
{
    public float fireRate = 0.5f;
    float lastFire = 0;
    ShootingComponent shootingComp;

    void Start()
    {
        shootingComp = GetComponent<ShootingComponent>();
    }

    public void Timing(float xPosition, float yPosition)
    {
        float currentTime = Time.time;
        if (lastFire + fireRate < currentTime)
        {
            shootingComp.ShootArrow(xPosition, yPosition);
            lastFire = currentTime;
        }
    }
}
