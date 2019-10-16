using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    GameObject lastArrow;
    GameObject currentArrow;
    private Skeleton skeleton;
    // Start is called before the first frame update
    void Start()
    {
        skeleton = GetComponent<Skeleton>();
    }

    // Update is called once per frame

    public void ShootArrow(GameObject arrowPrefab)
    {

        float a = Random.Range(0.0f, 1.0f) * 2 * (float)3.14;
        double r = 3 * Mathf.Sqrt(Random.Range(0.0f, 1.0f));
        float arrowXPosition = skeleton.xPosition + (float)r * Mathf.Cos(a);
        float arrowYPoisition = skeleton.yPosition + (float)r * Mathf.Sin(a);
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
