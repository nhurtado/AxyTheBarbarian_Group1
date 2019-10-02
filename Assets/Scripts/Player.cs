using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly float speed = 10f;
    Vector2 currentMovement;
    void FixedUpdate()
    {
        ProcessInput();
        UpdateState();
    }

    void ProcessInput()
    {
        currentMovement = new Vector2(0,0);
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            currentMovement.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            currentMovement.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            currentMovement.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            currentMovement.x -= speed * Time.deltaTime;
        }
    }

    void UpdateState()
    {
        transform.Translate(currentMovement);
    }
}
