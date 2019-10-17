﻿using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MapFactory : MonoBehaviour
{
    Vector2 position;
    public GameObject wallPrefab;
    public GameObject playerPrefab;
    public GameObject skeletonPrefab;
    public GameObject gazerPrefab;
    public GameObject doorPrefab;
    const string wall = "w";
    const string player = "p";
    const string gazer = "g";
    const string skeleton = "s";
    const string door = "d";
    // Start is called before the first frame update
    void Start()
    {

        GenerateMap();
    }
  
    public void GenerateMap()
    {
        string text = System.IO.File.ReadAllText("Assets/Resources/FirstLevel.txt");
        string[] lines = Regex.Split(text, "\r\n");
        foreach(string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            string[] objectPosition = line.Split(',');
            string objectType = objectPosition[0].ToLower();
            int objectPositionX = int.Parse(objectPosition[1]);
            int objectPositionY = int.Parse(objectPosition[2]);
            position = new Vector2(objectPositionX, objectPositionY);
            switch (objectType)
            {
                case wall:
                    Instantiate(wallPrefab, position, transform.rotation);
                    break;
                case player:
                    if (GameObject.Find("Player(Clone)") == null)
                    {
                        Instantiate(playerPrefab, position, transform.rotation);
                    }                    
                    break;
                case skeleton:
                    Instantiate(skeletonPrefab, position, transform.rotation);
                    break;
                case gazer:
                    Instantiate(gazerPrefab, position, transform.rotation);
                    break;
                case door:
                    Instantiate(doorPrefab, position, transform.rotation);
                    break;

            }

        }
    }
}