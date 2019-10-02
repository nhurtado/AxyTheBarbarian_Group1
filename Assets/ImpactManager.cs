using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ImpactManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EditorApplication.Beep();
        }
    }
}
