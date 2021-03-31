using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject tilePrefab;
    private List<GameObject> tiles = new List<GameObject>();

    private void Awake() => GridBuilder.OnGridBuilt += BuildTiles;

    private void BuildTiles()
    {
        for (var x = 0; x <= GridBuilder.width; x++)
        {
            for (var y = 0; y <= GridBuilder.height; y++)
            {
                var go = Instantiate(tilePrefab, new Vector3(x * Marker.Scale, y * Marker.Scale, transform.position.z),Quaternion.identity);
                go.transform.name = $"{x},{y}";
                go.transform.parent = transform;
                go.transform.localScale = Vector3.one * Marker.Scale;
                tiles.Add(go);
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var tile in tiles) 
            Destroy(tile);
    }
}
