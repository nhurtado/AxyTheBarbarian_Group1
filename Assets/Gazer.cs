using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazer : MonoBehaviour
{
    bool goingDown = true; //0 = Down, 1 = Up
    float speed = 5f;

    void Update()
    {
        UpdateState();
    }

    void UpdateState()
    {
        Vector2 vec = new Vector2(0,0);
        if (goingDown)
        {
            if (transform.position.y > -3)
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
            if (transform.position.y < 3)
            {
                vec.y += speed * Time.deltaTime;
            }
            else
            {
                goingDown = true;
            }
        }
        transform.Translate(vec);
    }
}
