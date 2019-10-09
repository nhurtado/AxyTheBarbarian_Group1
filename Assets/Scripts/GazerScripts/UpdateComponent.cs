using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateComponent : MonoBehaviour
{
    private Gazer gazer;
    private Vector2 vec;
    // Start is called before the first frame update
    void Start()
    {
        gazer = GetComponent<Gazer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vec = gazer.vec;
        UpdateState(gazer);
    }

    void UpdateState(Gazer gazer)
    {   
        gazer.transform.Translate(vec);
    }
}
