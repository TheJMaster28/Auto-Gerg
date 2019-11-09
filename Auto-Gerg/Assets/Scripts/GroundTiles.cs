using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTiles : MonoBehaviour
{
    // Variables for the tiles

    private bool tileOccupied = false;

    Vector3 topPosition;
    Vector3 position;
    Vector3 extra = new Vector3(0f, 0.2f, 0f);

    public GameObject chessPiece;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
        topPosition = position + extra;
        //print(position);        testing to make sure that im getting correct position
    }

    // Update is called once per frame
    void Update()
    {
        // Changing the status of a tile form empty to occupied if
        // there is a character piece above it.
        //
        // This compares the positions
        if(topPosition == Character.basePosition)
        {
            tileOccupied = true;
        }

        

    } // end of update

} // end of class
