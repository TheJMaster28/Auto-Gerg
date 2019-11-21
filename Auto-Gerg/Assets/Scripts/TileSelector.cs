using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    public GameObject tileHighlightPrefab;

    private GameObject tileHighlight;

    private GroundTiles groundTile;

    // Start is called before the first frame update
    void Start()
    {
        Vector2Int gridPoint = Geometry.GridPoint(0, 0);                 // these need to pull the x and y axis locations of the grid tiles
        Vector3 point = Geometry.PointFromGrid(gridPoint);               // need to do the same as the one above
        tileHighlight = Instantiate(tileHighlightPrefab, point, Quaternion.identity, gameObject.transform);
        tileHighlight.SetActive(false);
    }

    public void EnterState()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 point = hit.point;
            Vector2Int gridPoint = Geometry.GridFromPoint(point); // need to change these to get the location of the tile

            tileHighlight.SetActive(true);
            tileHighlight.transform.position = Geometry.PointFromGrid(gridPoint); // need to change these to get the location of the tile
        }
        else
        {
            tileHighlight.SetActive(false);
        }
    }
}
