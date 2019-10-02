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
        /* Old Way
        float currentTime = Time.deltaTime;
        if (lastFire + fireRate < currentTime)
        {
            currentArrow = Instantiate(arrowPrefab,
                new Vector2(xPosition + Random.Range(-3.0f, 3.0f),
                yPosition + Random.Range(-3.0f, 3.0f)),
                transform.rotation);
            if (lastArrow)
            {
                Destroy(lastArrow);
            }
            lastArrow = currentArrow;
            lastFire = currentTime;
        }*/
        float angle = Random.value * 360;
        float currentTime = Time.deltaTime;
        float radius = 3.0f;
        float arrowXPosition = xPosition + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        float arrowYPoisition = yPosition + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        if (lastFire + fireRate < currentTime)
        {
            currentArrow = Instantiate(arrowPrefab,
                new Vector2(arrowXPosition, arrowYPoisition), transform.rotation);
            if (lastArrow)
            {
                Destroy(lastArrow);
            }
            lastArrow = currentArrow;
            lastFire = currentTime;
        }
    }
}
