using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject Player;
    public List<GameObject> activeFieldMonsters = new List<GameObject> ();

    //defaults
    public float Health = 100.0f;
    private bool hasWonRound = false;
    private bool canSpawn = true;
    private bool hasEnded = false;

    // Start is called before the first frame update
    void Awake () {

    }

    // Update is called once per frame
    void Update () {

    }

    public float getHealth () {
        return Health;
    }

    public void SetWonRound (bool wr) {
        hasWonRound = wr;
    }

    public bool GetWonRound () {
        return hasWonRound;
    }

    public void SetHasEnded (bool hg) {
        hasEnded = hg;
    }

    public bool GetHasEnded () {
        return hasEnded;
    }

    public void TakeDamage (int takeDmg) {
        Health = Health - takeDmg;
    }

    public void setCanSpawn (bool s) {
        canSpawn = s;
    }

    public bool getCanSpawn () {
        return canSpawn;
    }

    public void addToActiveField (GameObject fieldMonster) {
        activeFieldMonsters.Add (fieldMonster);

    }

    public void resetPieces () {
        foreach (GameObject chara in activeFieldMonsters) {
            chara.GetComponent<Character> ().setIsDead (false);
            chara.GetComponent<CharacterAI> ().GoBackToOrginalTile ();
            chara.GetComponent<Character> ().revertHealth ();
            chara.GetComponent<Character> ().isMoving = false;
        }

    }

    public bool checkAllDeadMonsters () {
        //return false for 1st round, when there are no monsters spawned yet
        int currentRound = GameObject.FindGameObjectWithTag ("RoundManager").GetComponent<RoundManager> ().roundCount;
        bool activeBattle = GameObject.FindGameObjectWithTag ("RoundManager").GetComponent<RoundManager> ().BattleActive;
        if (currentRound == 1 && activeBattle == false) return false;

        //return false if we find at least one not dead monster
        foreach (GameObject chara in activeFieldMonsters) {
            if (chara.GetComponent<Character> ().getIsDead () == false)
                return false;
        }

        //at this point all monsters in activeField are dead
        return true;
    }

}