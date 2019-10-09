using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private Player player;
    private Vector2 currentMovement;
    void Start()
    {
        player = GetComponent<Player>();
    }
    
    void FixedUpdate()
    {
        currentMovement = player.currentMovement;
        UpdateState(player);
    }

    void UpdateState(Player player)
    {
        player.transform.Translate(currentMovement);
    }
}
