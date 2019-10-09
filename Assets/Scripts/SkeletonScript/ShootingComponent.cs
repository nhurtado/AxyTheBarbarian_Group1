using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    GameObject arrowPrefab;
    GameObject lastArrow;
    GameObject currentArrow;
    readonly float fireRate = 0.5f;
    float lastFire = 0;
    private Skeleton skeleton;
    private float xPosition;
    private float yPosition;
    // Start is called before the first frame update
    void Start()
    {
        skeleton = GetComponent<Skeleton>();
        this.xPosition = skeleton.xPosition;
        this.yPosition = skeleton.yPosition;
    }

    // Update is called once per frame
    void Update()
    {
        arrowPrefab = skeleton.arrowPrefab;
        ShootArrow();
    }
    public void ShootArrow()
    {
        float currentTime = Time.time;
        float a = Random.Range(0.0f, 1.0f) * 2 * (float)3.14;
        double r = 3 * Mathf.Sqrt(Random.Range(0.0f, 1.0f));
        float arrowXPosition = xPosition + (float)r * Mathf.Cos(a);
        float arrowYPoisition = yPosition + (float)r * Mathf.Sin(a);
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
