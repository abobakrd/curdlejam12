using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCamera : MonoBehaviour
{
    public Camera camera;

    public Vector3 offset = new Vector3(0, 0, -10);
    
    // Update is called once per frame
    private void Start()
    {
        camera.orthographicSize = GridBuilder.CenterPoint.x + 2;
        transform.position = GridBuilder.CenterPoint + offset;
    }
}
