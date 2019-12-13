using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    // total number of rows and columns
    public int rows;
    public int colums;

    // array of all tiles
    public GameObject[] tiles;

    private void Awake () {

        // set size of array
        tiles = new GameObject[rows * colums];

        int tileIndex = 0;

        // gets child of board(row) then gets all tiles in the row
        for (int i = 0; i < 8; i++) {
            GameObject row = transform.GetChild (i).gameObject;

            for (int k = 0; k < rows; k++) {
                tiles[tileIndex] = row.transform.GetChild (k).gameObject;
                row.transform.GetChild (k).gameObject.GetComponent<GroundTiles> ().boardNumber = tileIndex + 1;
                tileIndex++;
            }

        }
    }

    // equation to get row based on tile number
    public int getBoardRow (int tileNumber) {
        return (int) Mathf.Ceil (tileNumber / 8.0f);
    }

    // equation to get column based on tile number
    public int getBoardColumn (int tileNumber) {
        if (tileNumber % 8 == 0) {
            return 8;
        }
        return tileNumber % 8;
    }

    public GameObject getTile (int column, int row) {
        int num = ((row - 1) * 8) + column;
        return tiles[num - 1];
    }

}