using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazer : MonoBehaviour
{
    private MovementComponent movementComp;
    private UpdateComponent updateComp;
    public float yPosition;
    Vector2 vec;

    void Start()
    {
        movementComp = GetComponent<MovementComponent>();
        updateComp = GetComponent<UpdateComponent>();
        yPosition = transform.position.y;
    }

    void FixedUpdate()
    {
        vec = movementComp.UpdateState(yPosition);
        updateComp.UpdateState(vec);
    }
}
