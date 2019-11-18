using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObserverScript : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject gameOverScreen;
    int delay = 3;
    bool restarting = false;

    public void TriggerWinSequence()
    {
        if (!restarting){
            Instantiate(winScreen, transform);
            restarting = true;
            StartCoroutine(LoadLevelAfterDelay(delay));
        }
    }

    public void TriggerGameOverSequence()
    {
        if (!restarting)
        {
            Instantiate(gameOverScreen, transform);
            restarting = true;
            StartCoroutine(LoadLevelAfterDelay(delay));
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
