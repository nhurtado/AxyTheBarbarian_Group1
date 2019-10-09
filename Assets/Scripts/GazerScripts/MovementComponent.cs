using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    private Gazer gazer;
    readonly float speed = 5f;
    bool goingDown = true; //0 = Down, 1 = Up
    Vector2 vec = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        gazer = GetComponent<Gazer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateState();
        gazer.vec = vec;
    }
    void UpdateState()
    {
        vec = new Vector2(0, 0);
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
    }
}
