using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private TimingComponent timingComp;
    public float xPosition;
    public float yPosition;
    
    void Start()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        timingComp = GetComponent<TimingComponent>();
    }

    void FixedUpdate()
    {
        timingComp.Timing(xPosition, yPosition);
    }

}
