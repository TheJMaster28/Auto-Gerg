﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragnDrop : MonoBehaviour {
    private GameObject _drag;
    private Vector3 screenPosition;
    private Vector3 offset;

    private void Update () {
        if (_drag == null && Input.GetMouseButtonDown (0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            if (Physics.Raycast (ray, out hit, 100.0f)) {
                if (gameObject == hit.transform.gameObject) {
                    _drag = hit.transform.gameObject;
                    _drag.GetComponent<Character> ().isMoving = true;
                    _drag.GetComponent<Character> ().Tile.GetComponent<GroundTiles> ().chessPiece = null;
                    _drag.GetComponent<Character> ().Tile = null;
                    screenPosition = Camera.main.WorldToScreenPoint (_drag.transform.position);
                    offset = _drag.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
                }
            }
        }

        if (Input.GetMouseButtonUp (0)) {
            _drag.GetComponent<Character> ().isMoving = false;
            _drag = null;
        }

        if (_drag != null) {
            Vector3 currentScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint (currentScreenSpace) + offset;
            _drag.transform.position = new Vector3 (currentPosition.x, _drag.transform.position.y, currentPosition.z);
        }
    }
} // end of class