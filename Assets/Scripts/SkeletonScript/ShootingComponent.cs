using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    public GameObject arrowPrefab;
    GameObject lastArrow;
    GameObject currentArrow;
    public float shootingRange = 3;

    public void ShootArrow(float xPosition, float yPosition)
    {
        float a = Random.Range(0.0f, 1.0f) * 2 * (float)3.14;
        double r = shootingRange * Mathf.Sqrt(Random.Range(0.0f, 1.0f));
        float arrowXPosition = xPosition + (float)r * Mathf.Cos(a);
        float arrowYPoisition = yPosition + (float)r * Mathf.Sin(a);
        currentArrow = Instantiate(arrowPrefab,
                new Vector2(arrowXPosition, arrowYPoisition),
                transform.rotation);
        if (lastArrow)
        {
            Destroy(lastArrow);
        }
        lastArrow = currentArrow;
    }    
}
