﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]//Make private value visible to the editor
    private float interpolationMaxVal = 100f;

    public Transform startPointBottom, endPointBottom;
    public Transform startPointTop, endPointTop;
    private GameObject[] allBottomObstaclePrefabs;
    private GameObject[] allTopObstaclePrefabs;

    private GameObject[] preppedBottomObstacles;
    private GameObject[] preppedTopObstacles;

    public float timeBetweenObstacles = 0.5f;
    private float timeTilNextObstacle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Load prefabs in
        allBottomObstaclePrefabs = new GameObject[1];
        allBottomObstaclePrefabs[0] = Resources.Load("Prefabs/AllBottomObstacles/Obstacle0") as GameObject;
        Debug.Log("Loaded Bottom: " + allBottomObstaclePrefabs.Length);

        allTopObstaclePrefabs = new GameObject[1];
        allTopObstaclePrefabs[0] = Resources.Load("Prefabs/AllTopObstacles/Obstacle0") as GameObject;
        Debug.Log("Loaded Top: " + allTopObstaclePrefabs.Length);


        preppedBottomObstacles = new GameObject[allBottomObstaclePrefabs.Length * 3];
        for (int i = 0; i < preppedBottomObstacles.Length; i++)
        {
            preppedBottomObstacles[i] = Instantiate(allBottomObstaclePrefabs[(int)(i / 3)], gameObject.transform);
            preppedBottomObstacles[i].GetComponent<ObstacleScript>().setStartEndPoints(startPointBottom.position, endPointBottom.position, interpolationMaxVal);
        }

        preppedTopObstacles = new GameObject[allTopObstaclePrefabs.Length * 3];
        for (int i = 0; i < preppedBottomObstacles.Length; i++)
        {
            preppedTopObstacles[i] = Instantiate(allTopObstaclePrefabs[(int)(i / 3)], gameObject.transform);
            preppedTopObstacles[i].GetComponent<ObstacleScript>().setStartEndPoints(startPointTop.position, endPointTop.position, interpolationMaxVal);
        }

    }

    // Update is called once per frame
    void Update()
    {
        timeTilNextObstacle += Time.deltaTime;
        if (timeTilNextObstacle >= timeBetweenObstacles)
        {
            timeTilNextObstacle = 0;
            spawnObstacle(getObstacle());
        }
    }

    //Get a free obstacle from the bottom - Obstacles on the top will mirror those on the bottom
    private int getObstacle()
    {
        int index = -1;
        for (int i = 0; i < preppedBottomObstacles.Length; i++)
        {
            if ((index == -1 || Random.Range(0, 10) < 2) && !preppedBottomObstacles[i].GetComponent<ObstacleScript>().isTravelling())
                index = i;
        }
        return index;
    }

    private void spawnObstacle(int obstacleToSpawnIndex)
    {
        if (obstacleToSpawnIndex != -1)
        {
            float height = Random.Range(0, 10);//Set random height in relation to this obstacle's normal height position (Top or Bottom)
            preppedBottomObstacles[obstacleToSpawnIndex].GetComponent<ObstacleScript>().activateObstacle(height * 0.1f);
            preppedTopObstacles[obstacleToSpawnIndex].GetComponent<ObstacleScript>().activateObstacle(height * 0.1f);
        }
    }
}