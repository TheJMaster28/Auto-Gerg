using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public int rows;
    public int colums;

    
    public GameObject[] tiles;

    private void Start() {

        tiles = new GameObject[rows * colums];

        int tileIndex = 0;

        for ( int i = 0; i < 8; i++) {
            GameObject row = transform.GetChild(i).gameObject;

            for ( int k = 0; k < 8; k++ ) {
                tiles[tileIndex] = row.transform.GetChild(k).gameObject;
                tileIndex++;
            }

        }

        for (int i =0; i < tiles.Length; i++ ) {
            print(tiles[i]);
        }
    }

    
}



