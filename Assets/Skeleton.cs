using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject arrowPrefab;
    GameObject lastArrow;
    GameObject currentArrow;
    float xPosition;
    float yPosition;
    float fireRate = 0.5f;
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
        }
    }
}
