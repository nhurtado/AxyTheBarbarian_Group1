using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazer : MonoBehaviour
{
    private MovementComponent movementComp;
    private UpdateComponent updateComp;
    Vector2 vec;

    public Gazer(MovementComponent movementComp, UpdateComponent updateComp)
    {
        
    }

    void Start()
    {
        movementComp = GetComponent<MovementComponent>();
        updateComp = GetComponent<UpdateComponent>();
    }

    void FixedUpdate()
    {
        vec = movementComp.UpdateState();
        updateComp.UpdateState(vec);
    }
}
