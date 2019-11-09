using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTiles : MonoBehaviour
{
    // Variables for the tiles

    private bool characterOccupied = false;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
        //print(position);        testing to make sure that im getting correct position
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
