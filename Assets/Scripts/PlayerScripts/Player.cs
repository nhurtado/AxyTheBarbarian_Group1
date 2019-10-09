using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector2 currentMovement;
    private InputController inputCon;
    private PhysicsController physicsCon;
    private StateController stateCon;
    public int currentDirection;

    public Player(InputController inputCon, PhysicsController physicsCon, StateController stateCon)
    {
        this.inputCon = inputCon;
        this.physicsCon = physicsCon;
        this.stateCon = stateCon;
    }
}
