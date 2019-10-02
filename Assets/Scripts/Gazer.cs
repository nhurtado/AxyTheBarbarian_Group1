using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazer : MonoBehaviour
{
    readonly float speed = 5f;
    bool goingDown = true; //0 = Down, 1 = Up


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
