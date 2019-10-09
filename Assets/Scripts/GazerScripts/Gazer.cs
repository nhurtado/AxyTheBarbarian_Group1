using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazer : MonoBehaviour
{
    private MovementComponent movementComp;
    private UpdateComponent updateComp;
    public Vector2 vec;

    public Gazer(MovementComponent movementComp, UpdateComponent updateComp)
    {
        this.movementComp = movementComp;
        this.updateComp = updateComp;
    }
}
