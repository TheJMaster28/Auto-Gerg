using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTiles : MonoBehaviour
{
    // Variables for the tiles

    private bool tileOccupied = false;

    public Vector3 topPosition;
    public static Vector3 position;
    Vector3 extra = new Vector3(0f, 0.2f, 0f);

    public GameObject chessPiece;
    public bool isChessPieceOn;

    private Board gameBoard;
    public int boardNumber;

    [SerializeField]
    private List<GameObject> adjcentTiles = new List<GameObject>();

    public bool edge;


    public bool evenRow;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
        topPosition = position + extra;
        //print(position);        testing to make sure that im getting correct position
        gameBoard = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();
        print(gameObject.name);
        CreateAdjectTileList();
        
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

    void CreateAdjectTileList() { 
        // get column and row of current tile
        int column = gameBoard.getBoardColumn(boardNumber);
        int row = gameBoard.getBoardRow(boardNumber);
        
        // find adjcent tiles based rather it is a edge tile or on an even row
        if ( edge ) {
            addToList(column, row + 1);
            addToList(column + 1, row);
            addToList(column, row - 1);
            addToList(column - 1, row);
        }

        else if ( evenRow ) {
            
            addToList(column + 1, row - 1);
            addToList(column, row - 1);
            addToList(column + 1, row);
            addToList(column - 1, row);
            addToList(column + 1, row + 1);
            addToList(column, row + 1);

        }

        else {
            addToList(column - 1, row - 1);
            addToList(column, row - 1);
            addToList(column + 1, row);
            addToList(column - 1, row);
            addToList(column - 1, row + 1);
            addToList(column, row + 1);

        }
       

    }


    void addToList(int column, int row) {
        if ( column >= 1 && column <= 8 && row >= 1 && row <= 8 ) {
            adjcentTiles.Add(gameBoard.getTile(column, row));
        }
    }

    public List<GameObject> getAdjcentTiles() {
        return adjcentTiles;
    }


} // end of class
