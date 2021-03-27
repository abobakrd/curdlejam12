using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CenterCamera : MonoBehaviour
{
    public Camera camera;
    public Transform plane;
    public MeshRenderer planeRenderer;

    public Vector3 offset = new Vector3(0, 0, -10);
    
    // Update is called once per frame
    private void Start()
    {
        camera.orthographicSize = GridBuilder.CenterPoint.x + 2;
        transform.position = GridBuilder.CenterPoint + offset;
        plane.localScale= Vector3.one * Marker.Scale * 0.916f;
        
        
        var mat = planeRenderer.material;
        mat.DOTiling(new Vector2(GridBuilder.width, GridBuilder.height), 0);
        mat.DOOffset(new Vector2(0, -0.5f) * Marker.Scale, 0);
        planeRenderer.materials = new[] { mat };
    }
}
