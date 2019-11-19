using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour
{
    private RoundManager rm;

    private Character characterScript;

    private GroundTiles groundScript;

    public LayerMask enemyLayer;

    public float radius = 1f;

    private bool moveTurn;

    public float moveTimeSet = 1f;

    private float moveTime;

    public float attackTimeSet = 1f;

    private float attackTime;

    void Awake() {
        moveTurn = true;
        moveTime = moveTimeSet;
        rm = GameObject.FindGameObjectWithTag("RoundManager").GetComponent<RoundManager>();
        attackTime = attackTimeSet;
        characterScript = gameObject.GetComponent<Character>();
        groundScript = characterScript.Tile.GetComponent<GroundTiles>();
    }

    void Update()
    {
        if ( characterScript.isdead ) {
            return;
        }
        characterScript = gameObject.GetComponent<Character>();
        groundScript = characterScript.Tile.GetComponent<GroundTiles>();

        if (moveTurn && rm.BattleCameraActive == true ) {
            Move();

        }
        else if (rm.BattleCameraActive == true ) {
            Attack();
        }
        
    }

    private void Attack() {

        attackTime -= Time.deltaTime;

        if ( attackTime < 0 ) {
            
            print("ATTACK!");
            //Collider[] hits = Physics.OverlapSphere(transform.position, characterScript.getRange(), layer);

            GameObject enemy = EnemyWithinRange();
            if (enemy != null ) {
                enemy.GetComponent<Character>().health -= characterScript.getAttackDamage();
            }
            

            attackTime = attackTimeSet;
        }
        
    }

   

    private void Move() {
        
        moveTime -= Time.deltaTime;

        if (moveTime < 0 ) {

            Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

            Vector3 closetEnemy;

            if (hits.Length != 0) {
                closetEnemy = ClosestEnemy(hits);

                GameObject moveTo = FindClosestTile(closetEnemy);

                if (!moveTurn) {
                    return;
                }

                moveTo.GetComponent<GroundTiles>().chessPiece = gameObject;

                groundScript.chessPiece = null;

                transform.position = moveTo.GetComponent<GroundTiles>().topPosition + new Vector3(0f,.5f,0f );

                characterScript.Tile = moveTo;

                

            }

            

            moveTime = moveTimeSet;
        }

    }

    private GameObject FindClosestTile(Vector3 closetEnemy) {

        
        List<GameObject> adjcentTiles = groundScript.getAdjcentTiles();

        float close = float.PositiveInfinity;
        GameObject closeV = adjcentTiles[0];




        foreach (GameObject aTile in adjcentTiles) {
            Vector3 tilepostion = aTile.transform.position;
            float dis = Vector3.Distance(closetEnemy, tilepostion);
            if (close > dis) {
                close = dis;
                closeV = aTile;
            }

        }


        for (int i = 0; i < characterScript.getRange(); i++) {

            foreach (GameObject aTile in adjcentTiles) {
                GameObject piece = aTile.GetComponent<GroundTiles>().chessPiece;
                if (piece != null ) {


                    if (((1 << piece.layer) & enemyLayer) != 0) {
                        moveTurn = false;
                        return null;
                    }

                    
                }

            }
            adjcentTiles = getOuterRingOfAdjTiles(adjcentTiles);

        }


        

        return closeV;

    }

    List<GameObject> getOuterRingOfAdjTiles(List<GameObject> adjcentTiles) {

        List<GameObject> outerRing = new List<GameObject>();

        foreach (GameObject aTile in adjcentTiles) {
            List<GameObject> aTileAdj = aTile.GetComponent<GroundTiles>().getAdjcentTiles();

            foreach (GameObject AdjTile in aTileAdj) {
                if (!adjcentTiles.Contains(AdjTile)) {
                    outerRing.Add(AdjTile);
                }
            }

        }

        
        return outerRing;
    }

    private Vector3 ClosestEnemy(Collider[] hits) {
        float close = float.PositiveInfinity;
        Vector3 closeV = Vector3.zero;
        
        for ( int i = 0; i < hits.Length; i++) {
            Vector3 enemyPostion = hits[i].transform.position;
            float dis = Vector3.Distance(transform.position, enemyPostion);
            if ( close >  dis ) {
                close = dis;
                closeV = enemyPostion;
            }
        }

        return closeV;
    }

    private GameObject EnemyWithinRange() {

        List<GameObject> adjcentTiles = groundScript.getAdjcentTiles();

        for (int i = 0; i < characterScript.getRange(); i++) {

            foreach (GameObject aTile in adjcentTiles) {
                GameObject piece = aTile.GetComponent<GroundTiles>().chessPiece;
                if (piece != null) {

                    if (((1 << piece.layer) & enemyLayer) != 0) {
                        return piece;
                    }
                }
            }
            adjcentTiles = getOuterRingOfAdjTiles(adjcentTiles);

        }

        moveTurn = true;
        return null;
        
    }

}
