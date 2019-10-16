using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateComponent : MonoBehaviour
{
    public void UpdateState(Vector2 vec)
    {   
        transform.Translate(vec);
    }
}
