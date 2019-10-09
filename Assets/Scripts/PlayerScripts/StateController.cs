using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.gameObject.tag == "Exit")
        {

        }
    }
}
