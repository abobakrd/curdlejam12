using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    public static Vector3 CenterPoint;
    
    public float scale;
    public GameObject playerPrefab;
    public GameObject goalPrefab;
    public GameObject markerPrefab;

    public static int width => maze.GetLength(0);
    public static int height => maze.GetLength(1);
    
    private GameObject playerInstance;
    private GameObject goalInstance;

    private List<GameObject> markerInstances = new List<GameObject>();

    private static int[,] maze = new [,]
    {
        {0,0,0,0,0,0,8,0},
        {0,0,0,0,5,0,0,0},
        {3,0,0,0,0,0,3,0},
        {0,0,5,0,0,3,0,0},
        {9,5,0,0,0,0,0,0},
        {0,3,0,0,0,2,0,0},
        {0,0,0,0,4,0,0,0},
        {0,0,0,0,0,0,0,0},
    };

    private void Awake()
    {
        var halfScale = 0.5f * scale;
        Marker.Scale = scale;
        
        CenterPoint = new Vector3(maze.GetLength(0) * halfScale, maze.GetLength(1) * halfScale);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (maze[x,y] == 9)
                    SpawnPlayer(y, x);
                else if (maze[x,y] == 8)
                    SpawnGoal(y, x);
                else if (maze[x,y] != 0)
                    SpawnMarker(y, x, maze[x, y]);
            }
        }
    }

    private void SpawnMarker(int x, int y, int distance)
    {
        var go = Instantiate(markerPrefab, new Vector3(x * scale, y * scale), Quaternion.identity);
        go.GetComponentInChildren<Marker>().SetDistance(distance);
    }

    private void SpawnGoal(int x, int y)
    {
        if(goalInstance != null) Destroy(goalInstance);

        goalInstance = Instantiate(goalPrefab, new Vector3(x * scale, y * scale), Quaternion.identity);
    }

    private void SpawnPlayer(int x, int y)
    {
        if (playerInstance != null) Destroy(playerInstance);

        playerInstance = Instantiate(playerPrefab, new Vector3(x * scale, y * scale), Quaternion.identity);
    }
}
