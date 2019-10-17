using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float speed = 5f;
    bool goingDown = true; //0 = Down, 1 = Up

    public Vector2 UpdateState(float yPosition)
    {
        Vector2 vec = new Vector2(0, 0);
        if (goingDown)
        {
            if (transform.position.y > -3 + yPosition)
            {
                vec.y -= speed * Time.deltaTime;
            }
            else
            {
                goingDown = false;
            }
        }
        else
        {
            if (transform.position.y < 3 + yPosition)
            {
                vec.y += speed * Time.deltaTime;
            }
            else
            {
                goingDown = true;
            }
        }
        return vec;
    }
}
