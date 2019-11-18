using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRangeDetection : MonoBehaviour
{
    RatManager rm;
    void Start()
    {
        rm = GetComponentInParent<RatManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (rm.player == null)
            {
                rm.player = other;
            }
            rm.worldState["CloserThan5"] = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rm.worldState["CloserThan5"] = false;
        }
    }
}
