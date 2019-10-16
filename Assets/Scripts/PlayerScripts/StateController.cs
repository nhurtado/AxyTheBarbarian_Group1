using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateController : MonoBehaviour
{
    public GameObject Observer;
    ObserverScript observerScript;
    Player player;

    void Start()
    {
        observerScript = Observer.GetComponent<ObserverScript>();
        player = GetComponent<Player>();
    }

    public void UpdateState(bool canMove, Vector2 currentMovement)
    {
        if (canMove)
        {
            transform.Translate(currentMovement);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Enemy")
        {
            observerScript.TriggerGameOverSequence();
            player.canMove = false;
        }
        if (other.gameObject.tag == "Exit")
        {
            observerScript.TriggerWinSequence();
            player.canMove = false;
        }
    }
}
