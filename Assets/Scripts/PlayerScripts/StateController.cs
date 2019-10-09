using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateController : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject gameOverScreen;
    private Player player;
    float endTime = float.MaxValue;
    private Vector2 currentMovement;
    private bool restartLevel = false;
    void Start()
    {
        player = GetComponent<Player>();
    }
    
    void FixedUpdate()
    {
        currentMovement = player.currentMovement;
        UpdateState(player);
        checkEndCondition();
    }

    void UpdateState(Player player)
    {
        if (player.canMove)
        {
            player.transform.Translate(currentMovement);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Enemy")
        {
            Instantiate(gameOverScreen, transform);
            restartLevel = true;
        }
        if (other.gameObject.tag == "Exit")
        {
            Instantiate(winScreen, transform);
            restartLevel = true;
        }
    }

    void checkEndCondition()
    {
        if (restartLevel)
        {
            endTime = Time.time + 3;
            restartLevel = false;
            player.canMove = false;
        }
        if (Time.time > endTime)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
