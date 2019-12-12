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
        Debug.Log (other.gameObject.name);
        if (!other.gameObject.GetComponent<Character> ().isMoving) {
            other.gameObject.transform.position = gameObject.GetComponent<GroundTiles> ().topPosition + new Vector3 (0f, .5f, 0f);
            gameObject.GetComponent<GroundTiles> ().chessPiece = other.gameObject;
            other.gameObject.GetComponent<Character> ().Tile = gameObject;
        }

    }
}