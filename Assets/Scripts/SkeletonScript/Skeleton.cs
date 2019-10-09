using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject arrowPrefab;
    private ShootingComponent shootingComp;
    private TimingComponent timingComp;
    public float xPosition;
    public float yPosition;
    public Skeleton(ShootingComponent shootingComp, TimingComponent timingComp)
    {
        this.shootingComp = shootingComp;
        this.timingComp = timingComp;
    }
    void Start()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
    }

}
