using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSnapCharacter : MonoBehaviour {
    // Start is called before the first frame update
    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay (Collider other) {

        if (!other.gameObject.GetComponent<Character> ().isMoving) {

            if (gameObject.GetComponent<GroundTiles> ().chessPiece != null) {

                MovePiece (other.gameObject, other.gameObject.GetComponent<CharacterAI> ().orginalTile);
                return;

            }

            MovePiece (other.gameObject, gameObject);
            // other.gameObject.transform.position = gameObject.GetComponent<GroundTiles> ().topPosition + new Vector3 (0f, .5f, 0f);
            // gameObject.GetComponent<GroundTiles> ().chessPiece = other.gameObject;
            // other.gameObject.GetComponent<Character> ().Tile = gameObject;
        }

    }
    void MovePiece (GameObject piece, GameObject tile) {
        piece.transform.position = tile.GetComponent<GroundTiles> ().topPosition + new Vector3 (0f, .5f, 0f);
        if (piece.GetComponent<Character> ().Tile != null) {
            piece.GetComponent<Character> ().Tile.GetComponent<GroundTiles> ().chessPiece = null;
        }
        tile.GetComponent<GroundTiles> ().chessPiece = piece;
        piece.GetComponent<Character> ().Tile = tile;
    }
}