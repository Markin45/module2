using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapEditor : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile tile;

    Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var pos = Cam.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(pos), tile);
        }
    }
}
