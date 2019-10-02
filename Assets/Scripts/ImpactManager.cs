using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ImpactManager : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EditorApplication.Beep();
        }
    }
}
