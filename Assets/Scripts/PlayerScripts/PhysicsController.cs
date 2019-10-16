using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    readonly float speed = 10f;

    public Vector2 ProcessInput(int currentDirection)
    {
        Vector2 currentMovement = new Vector2(0, 0);
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
        return currentMovement;
    }
}
