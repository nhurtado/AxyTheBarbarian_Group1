using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazer : MonoBehaviour
{
    bool goingDown = true; //0 = Down, 1 = Up
    Vector2 currentMovement;
    float speed = 5f;

    void Update()
    {
        UpdateState();
    }

    void UpdateState()
    {
        currentMovement = transform.position;
        if (goingDown)
        {
            if (transform.position.y > -3)
            {
                currentMovement.y -= speed * Time.deltaTime;
            }
            else
            {
                goingDown = false;
            }
        }
        else
        {
            if (transform.position.y < 3)
            {
                currentMovement.y += speed * Time.deltaTime;
            }
            else
            {
                goingDown = true;
            }
        }
        transform.position = currentMovement;
    }
}
