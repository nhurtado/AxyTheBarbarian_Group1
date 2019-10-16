using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    public int currentDirection;
    public Vector2 currentMovement;
    public bool canMove = true;
    InputController inputController;
    PhysicsController physicsController;
    StateController stateController;

    void Start()
    {
        inputController = GetComponent<InputController>();
        physicsController = GetComponent<PhysicsController>();
        stateController = GetComponent<StateController>();
    }

    void Update()
    {
        currentDirection = inputController.GetInput();
        currentMovement = physicsController.ProcessInput(currentDirection);
        stateController.UpdateState(canMove, currentMovement);
    }
}
