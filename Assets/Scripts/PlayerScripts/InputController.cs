using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public int GetInput()
    {
        int currentDirection = 0;
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            currentDirection = 1;
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            currentDirection = 2;
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            currentDirection = 3;
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            currentDirection = 4;
        }
        return currentDirection;
    }
}
