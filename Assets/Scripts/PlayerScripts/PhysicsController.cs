using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    readonly float speed = 10f;
    private int currentDirection;
    private Vector2 currentMovement;
    private Player player;

    public void Start()
    {
        player = GetComponent<Player>();
    }
    
    void Update()
    {
        currentDirection = player.currentDirection;
        ProcessInput();
        player.currentMovement = currentMovement;
    }

    public void ProcessInput()
    {
        currentMovement = new Vector2(0, 0);
        if (currentDirection == 1)
        {
            currentMovement.y += speed * Time.deltaTime;
        }
        if (currentDirection == 2)
        {
            currentMovement.y -= speed * Time.deltaTime;
        }
        if (currentDirection == 3)
        {
            currentMovement.x += speed * Time.deltaTime;
        }
        if (currentDirection == 4)
        {
            currentMovement.x -= speed * Time.deltaTime;
        }
    }
}
