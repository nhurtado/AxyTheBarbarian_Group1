using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject arrowPrefab;
    GameObject lastArrow;
    GameObject currentArrow;
    readonly float fireRate = 0.5f;
    float xPosition;
    float yPosition;
    float lastFire = 0;
    void Start()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
    }

    void Update()
    {
        ShootArrow();
    }

    void ShootArrow()
    {
        float currentTime = Time.time;
        float a = Random.Range(0.0f, 1.0f) * 2 * (float) 3.14;
        double r = 3 * Mathf.Sqrt(Random.Range(0.0f, 1.0f));
        float arrowXPosition = xPosition + (float) r * Mathf.Cos(a);
        float arrowYPoisition = yPosition + (float) r * Mathf.Sin(a);
        if (lastFire + fireRate < currentTime)
        {
            currentArrow = Instantiate(arrowPrefab,
                new Vector2(arrowXPosition, arrowYPoisition),
                transform.rotation);
            if (lastArrow)
            {
                Destroy(lastArrow);
            }
            lastArrow = currentArrow;
            lastFire = currentTime;
        }
    }
}
