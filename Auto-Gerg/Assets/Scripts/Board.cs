using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Board : MonoBehaviour
{

    public int rows;
    public int colums;

    
    public GameObject[] tiles;

    private void Awake() {

        tiles = new GameObject[rows * colums];

        int tileIndex = 0;

        for ( int i = 0; i < 8; i++) {
            GameObject row = transform.GetChild(i).gameObject;

            for ( int k = 0; k < 8; k++ ) {
                tiles[tileIndex] = row.transform.GetChild(k).gameObject;
                row.transform.GetChild(k).gameObject.GetComponent<GroundTiles>().boardNumber = tileIndex +1;
                tileIndex++;
            }

        }

        //for (int i =0; i < tiles.Length; i++ ) {
        //    print(tiles[i]);
        //}
    }

    public int getBoardRow(int pieceNum) {
        return (int)Mathf.Ceil(pieceNum / 8.0f);
    }

    public int getBoardColumn(int pieceNum) {
        if ( pieceNum % 8  == 0 ) {
            return 8;
        }
        return pieceNum % 8;
    }
    
    public GameObject getTile(int column, int row) {
        print("Board column:" + column + " row: " + row);


        int num = ((row - 1)  * 8 ) + column;
        print("num: " + num);
        return tiles[ num -1 ];
    }

}



