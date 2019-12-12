using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour {

    public GameObject player;

    public GameObject rm;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void EndTurn () {
        //set player's isTurn to false when they click on the end turn button
        player.GetComponent<PlayerManager> ().SetHasEnded (true);
        player.GetComponent<PlayerManager> ().setCanSpawn (false);

        if (player.tag.Equals ("PlayerManager1")) {
            GameObject.FindGameObjectWithTag ("PlayerManager2").GetComponent<PlayerManager> ().setCanSpawn (true);
        } else {
            GameObject.FindGameObjectWithTag ("PlayerManager1").GetComponent<PlayerManager> ().setCanSpawn (true);
        }
        rm.GetComponent<RoundManager> ().nextTurn = true;

    }

}