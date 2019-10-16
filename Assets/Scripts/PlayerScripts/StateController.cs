using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateController : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject gameOverScreen;
    private float endTime = float.MaxValue;
    private bool restartLevel = false;
    private float currentTime = 0;

    public void UpdateState(bool canMove, Vector2 currentMovement)
    {
        if (canMove)
        {
            transform.Translate(currentMovement);
        }
    }

    public bool CheckEndCondition(bool canMove)
    {
        currentTime = Time.time;
        if (restartLevel && endTime > currentTime)
        {
            endTime = Time.time;
            canMove = false;
        }
        else if (endTime + 3 < currentTime)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        return canMove;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!restartLevel)
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
    }
}
