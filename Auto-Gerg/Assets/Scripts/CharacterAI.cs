using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour {
    // get round manger for accessing round manager to see if it is in battle phase
    private RoundManager rm;

    // quicker way of writing GetComponent<Character>
    private Character characterScript;

    // quicker way of writing GetComponent<GroundScript>
    private GroundTiles groundScript;

    // other player's pieces layer 
    public LayerMask enemyLayer;

    public string enemyTag;

    // used in Overlap share function
    public float radius = 10f;

    // can move bool switch
    private bool moveTurn;

    // time to move
    public float moveTimeSet = 1f;

    // time to move character
    private float moveTime;

    // time between attacks
    private float attackTime;

    void Awake () {

        // grab scripts from gameObject
        characterScript = gameObject.GetComponent<Character> ();
        groundScript = characterScript.Tile.GetComponent<GroundTiles> ();

        // defualt to moving 
        moveTurn = true;
        moveTime = moveTimeSet;

        // grab RoundManager gameObject
        rm = GameObject.FindGameObjectWithTag ("RoundManager").GetComponent<RoundManager> ();

        // get attack speed from character Script
        attackTime = characterScript.getAttackSpeed ();

    }

    void Update () {

        // get new calls since scripts values change
        characterScript = gameObject.GetComponent<Character> ();
        groundScript = characterScript.Tile.GetComponent<GroundTiles> ();

        // if character is dead, no AI
        if (characterScript.isdead) {
            return;
        }

        // if you can move and we are in battle mode, move
        if (moveTurn && rm.BattleCameraActive == true) {
            Move ();

        }
        // otherwise we attack
        else if (rm.BattleCameraActive == true) {
            Attack ();
        }

    }

    // Attack Steps
    private void Attack () {

        // reduce time
        attackTime -= Time.deltaTime;

        // timer ran out, attack
        if (attackTime < 0) {

            print ("ATTACK!");

            // find enemy within range
            GameObject enemy = EnemyWithinRange ();

            // attack enemy that is within range
            if (enemy != null) {
				
				float modifiedDamage = 0;
				
				//set modifiedDamage to damage - enemy armor or resistance//
				if(characterScript.getAttackType() == "Physical")
					modifiedDamage = characterScript.getAttackDamage () - enemy.GetComponent<Character>().getArmor();
				else if(characterScript.getAttackType() == "Magical")
					modifiedDamage = characterScript.getAttackDamage () - enemy.GetComponent<Character>().getResistance();
				else
					print("Set a proper Character Attack Type");
				
				//deal modifiedDamage to enemy
				if(modifiedDamage > 0)
					enemy.GetComponent<Character> ().health -= modifiedDamage;
				else 
					enemy.GetComponent<Character> ().health -= 1;
				
				
				
            }

            // reset timer
            attackTime = characterScript.getAttackSpeed ();
        }

    }

    // Move Steps
    private void Move () {

        // reduce time
        moveTime -= Time.deltaTime;

        // timer ran out, move
        if (moveTime < 0) {

            // get all eneimes in enemylayer
            Collider[] hits = Physics.OverlapSphere (transform.position, radius, enemyLayer);

            // postion of the cloest enemy
            Vector3 closetEnemy;

            // if we get any hits
            if (hits.Length != 0) {

                // find cloest enemy
                closetEnemy = ClosestEnemy (hits);

                // then find cloest tile within its adject list
                GameObject moveTo = FindClosestTile (closetEnemy);

                // if we are no longer moving, stop
                if (!moveTurn) {
                    moveTime = moveTimeSet;
                    return;
                }

                if (moveTo == null) {
                    moveTime = moveTimeSet;
                    return;
                }

                // set refernece of the new tile to move to, to the gameObect
                moveTo.GetComponent<GroundTiles> ().chessPiece = gameObject;

                // remove refernce from old tile
                groundScript.chessPiece = null;

                // move gameobject to the new tile
                transform.position = moveTo.GetComponent<GroundTiles> ().topPosition + new Vector3 (0f, .5f, 0f);

                // set tile refernce to new tile
                characterScript.Tile = moveTo;

            }

            // reset tile
            moveTime = moveTimeSet;
        }

    }

    private GameObject FindClosestTile (Vector3 closetEnemy) {

        // grab list
        List<GameObject> adjcentTiles = groundScript.getAdjcentTiles ();

        float close = float.PositiveInfinity;
        GameObject closeV = adjcentTiles[0];

        // go through each tile in list to see if postion is closer
        foreach (GameObject aTile in adjcentTiles) {

            Vector3 tilepostion = aTile.transform.position;

            float dis = Vector3.Distance (closetEnemy, tilepostion);

            // if there is a chess piece near me, then quit
            if (aTile.GetComponent<GroundTiles> ().chessPiece != null) {
                continue;
            }

            if (close > dis) {
                close = dis;
                closeV = aTile;
            }

        }

        // go through tiles within range to see if there are eneimes
        for (int i = 0; i < characterScript.getRange (); i++) {

            foreach (GameObject aTile in adjcentTiles) {
                GameObject piece = aTile.GetComponent<GroundTiles> ().chessPiece;
                if (piece != null) {

                    // suppose to stop moving when a enemy piece around
                    // if ( ((1 << piece.layer) & enemyLayer) != 0 ) {
                    //     moveTurn = false;
                    //     return null;
                    // }
                    if (piece.tag == enemyTag) {
                        moveTurn = false;
                        return null;
                    }

                }

            }

            // get outer "ring" of tiles' adject list to get next tile rnage up
            adjcentTiles = getOuterRingOfAdjTiles (adjcentTiles);

        }

        return closeV;

    }

    // create new list of outer tiles
    List<GameObject> getOuterRingOfAdjTiles (List<GameObject> adjcentTiles) {

        List<GameObject> outerRing = new List<GameObject> ();

        // for each tile in current tile's adject list
        foreach (GameObject aTile in adjcentTiles) {
            List<GameObject> aTileAdj = aTile.GetComponent<GroundTiles> ().getAdjcentTiles ();

            // each adject tile adject list
            foreach (GameObject AdjTile in aTileAdj) {

                // add only if it is not in list
                if (!adjcentTiles.Contains (AdjTile)) {
                    outerRing.Add (AdjTile);
                }
            }

        }

        return outerRing;
    }

    // find closet enemy
    private Vector3 ClosestEnemy (Collider[] hits) {

        float close = float.PositiveInfinity;
        Vector3 closeV = Vector3.zero;

        // go through array and calcuate distance between gameObject postion and other players pieces
        for (int i = 0; i < hits.Length; i++) {
            Vector3 enemyPostion = hits[i].transform.position;
            float dis = Vector3.Distance (transform.position, enemyPostion);
            if (close > dis) {
                close = dis;
                closeV = enemyPostion;
            }
        }

        return closeV;
    }

    // check if eneiems are within range
    private GameObject EnemyWithinRange () {

        List<GameObject> adjcentTiles = groundScript.getAdjcentTiles ();

        for (int i = 0; i < characterScript.getRange (); i++) {

            foreach (GameObject aTile in adjcentTiles) {

                GameObject piece = aTile.GetComponent<GroundTiles> ().chessPiece;

                if (piece != null) {

                    // float layerNumber = Mathf.Log(enemyLayer.value, 2);
                    // if piece is on a the eneimes layer, return piece
                    // if ( ((1 << piece.layer) & enemyLayer) != 0 ) {
                    //     //moveTurn = false;
                    //     return piece;
                    // }
                    if (piece.tag == enemyTag) {
                        return piece;
                    }

                }
            }
            adjcentTiles = getOuterRingOfAdjTiles (adjcentTiles);

        }

        moveTurn = true;
        return null;

    }

}