using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour
{
    private RoundManager rm;

    public LayerMask layer;

    public float radius = 1f;


    private bool moveTurn;

    public float moveTimeSet = 1f;

    private float moveTime;

    void Awake() {
        moveTurn = true;
        moveTime = moveTimeSet;
        rm = GameObject.FindGameObjectWithTag("RoundManager").GetComponent<RoundManager>();
    }

    void Update()
    {
        if (moveTurn && rm.BattleCameraActive == true ) {
            Move();

        }
        else {

        }
        
    }

    private void Move() {

        moveTime -= Time.deltaTime;

        if (moveTime < 0 ) {

            Collider[] hits = Physics.OverlapSphere(transform.position, radius, layer);

            Vector3 closetEnemy = Vector3.zero;

            if (hits.Length != 0) {
                closetEnemy = ClosestEnemy(hits);

                GameObject moveTo = FindClosestTile(closetEnemy);

                if (!moveTurn) {
                    return;
                }

                moveTo.GetComponent<GroundTiles>().chessPiece = gameObject;

                gameObject.GetComponent<Character>().Tile.GetComponent<GroundTiles>().chessPiece = null;

                transform.position = moveTo.GetComponent<GroundTiles>().topPosition + new Vector3(0f,.5f,0f );

                gameObject.GetComponent<Character>().Tile = moveTo;
            }

            

            moveTime = moveTimeSet;
        }

    }

    private GameObject FindClosestTile(Vector3 closetEnemy) {

        GroundTiles tile = gameObject.GetComponent<Character>().Tile.GetComponent<GroundTiles>();
        List<GameObject> adjcentTiles = tile.getAdjcentTiles();

        float close = float.PositiveInfinity;
        GameObject closeV = adjcentTiles[0];
        foreach ( GameObject aTile in adjcentTiles) {


            if (aTile.GetComponent<GroundTiles>().chessPiece != null ) {
                moveTurn = false;
                return null;
            }

            Vector3 tilepostion = aTile.transform.position;
            float dis = Vector3.Distance(closetEnemy, tilepostion);
            if (close > dis) {
                close = dis;
                closeV = aTile;
            }

        }

        return closeV;

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
}
