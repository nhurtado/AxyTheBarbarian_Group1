using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            SetTarget();
        }
    }

    void SetTarget()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Pathfinding.AIDestinationSetter>().target = player.transform;
    }


}
