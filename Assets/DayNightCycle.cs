using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    public bool day = true;
    private float nextActionTime = 0.0f;
    public float period = 15.0f;

    Color dayTime = new Color(0, 0, 55, 0);
    Color nightTime = new Color32(55, 55, 0, 0);

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            SwapBackgrounds();
            nextActionTime += period;
        }
    }

    void SwapBackgrounds()
    {
        if (day)
        {
            Camera.main.GetComponent<Camera>().backgroundColor = dayTime;
        }
        else
        {
            Camera.main.GetComponent<Camera>().backgroundColor = nightTime;
        }
        day = !day;
    }
}
