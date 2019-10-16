using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingComponent : MonoBehaviour
{
    GameObject arrowPrefab;
    readonly float fireRate = 0.5f;
    float lastFire = 0;
    private Skeleton skeleton;
    private ShootingComponent shootingComponent;
    // Start is called before the first frame update
    void Start()
    {
        skeleton = GetComponent<Skeleton>();
        shootingComponent = skeleton.shootingComp;
    }

    // Update is called once per frame
    void Update()
    {
        arrowPrefab = skeleton.arrowPrefab;
        Timing();
    }

    public void Timing()
    {
        float currentTime = Time.time;
        if (lastFire + fireRate < currentTime)
        {
            shootingComponent.ShootArrow(arrowPrefab);
            lastFire = currentTime;
        }
    }
}
