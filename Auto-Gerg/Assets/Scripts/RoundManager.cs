using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour {

    public GameObject P1Camera;
    public GameObject P2Camera;
    public GameObject P1;
    public GameObject P2;
    public GameObject BattleCamera;

    public int roundCount;

    public bool BattleActive;

    public bool P1AllMonstersDead;
    public bool P2AllMonstersDead;

    // Start is called before the first frame update
    void Awake () {
        roundCount = 1;
        BattleActive = false;
    }

    // Update is called once per frame
    void Update () {
        P1AllMonstersDead = P1.GetComponent<PlayerManager>().checkAllDeadMonsters();
        Debug.Log("P1AllMonstersDead: " +
            P1AllMonstersDead);
        P2AllMonstersDead = P2.GetComponent<PlayerManager>().checkAllDeadMonsters();
        Debug.Log("P2AllMonstersDead: " +
           P1AllMonstersDead);

        if (P1.GetComponent<PlayerManager>().activeFieldMonsters.Count >= roundCount && P1.GetComponent<PlayerManager>().GetHasEnded() == false) //player 1 hit max spawns for the round
        {
            if (P1.GetComponent<PlayerManager>().getCanSpawn() == false) { Debug.Log("P1 Max Spawn reached for the round"); } //change this to UI later
            P1.GetComponent<PlayerManager>().setCanSpawn(false);
        }

        if (P2.GetComponent<PlayerManager>().activeFieldMonsters.Count >= roundCount && P2.GetComponent<PlayerManager>().GetHasEnded() == false) //player 2 hit max spawns for the round
        {
            if (P2.GetComponent<PlayerManager>().getCanSpawn() == false) { Debug.Log("P2 Max Spawn reached for the round"); } //change this to UI later
            P2.GetComponent<PlayerManager>().setCanSpawn(false);
        }


        if (BattleActive == true) {

            if (P1AllMonstersDead == true) {
                P2.GetComponent<PlayerManager>().SetWonRound(true);
                //UI Announce P1 round winner
                //P2 take damage
                P2.GetComponent<PlayerManager>().TakeDamage(10);
                RoundReset();
            } else if(P2AllMonstersDead == true)
            {
                P1.GetComponent<PlayerManager>().SetWonRound(true);
                //UI Announce P2 as round winner
                //P1 take damage
                P1.GetComponent<PlayerManager>().TakeDamage(10);
                RoundReset();
            }
        }

        //Be checking for ultimate winner
        if(P1.GetComponent<PlayerManager>().getHealth() < 0.0f)
        {
            //oof p1
        }
        else if (P2.GetComponent<PlayerManager>().getHealth() < 0.0f)
        {
            //oof p2
        }
    }

    private void LateUpdate () {
        CameraTurnManager ();
    }

    //resets bool values for pre-round
    private void RoundReset () {

        CameraTurnManager();

        P1.GetComponent<PlayerManager> ().resetPieces ();
        P2.GetComponent<PlayerManager> ().resetPieces ();

        P1.GetComponent<PlayerManager> ().SetWonRound (false);
        P1.GetComponent<PlayerManager> ().SetHasEnded (false);
        P1.GetComponent<PlayerManager>().setCanSpawn(true);

        P2.GetComponent<PlayerManager> ().SetWonRound (false);
        P2.GetComponent<PlayerManager> ().SetHasEnded (false);
        P2.GetComponent<PlayerManager>().setCanSpawn(true);


        roundCount++;
        BattleActive = false;
    }


    public void CameraTurnManager () {

        bool p1HasEnded = P1.GetComponent<PlayerManager> ().GetHasEnded ();
        bool p2HasEnded = P2.GetComponent<PlayerManager> ().GetHasEnded ();

        bool p1HasWonPrevious = P1.GetComponent<PlayerManager>().GetWonRound();
        bool p2HasWonPrevious = P2.GetComponent<PlayerManager>().GetWonRound();
        
        //checks who won from the previous round (excludes 1st round) to determine which player goes first on roundCount > 1
        if(p1HasWonPrevious == true && p2HasWonPrevious == false)
        {
            SwitchToP1();
        } else
        {
            SwitchToP2();
        }

        //Player 1 hasGone Player 2 has not, switch to Player 2 Cam
        if (p1HasEnded == true && p2HasEnded == false) {
            SwitchToP2 ();
        }
        //Player 2 hasGone Player 1 has not, switch to Player 1 Cam
        else if (p1HasEnded == false && p2HasEnded == true) {
            SwitchToP1 ();
        }
        //Both players have ended their turn, switch to battle
        else if (p1HasEnded = true && p2HasEnded == true) {
            SwitchToBattle ();
        }
        //default to player 1 for now
        else {
            SwitchToP1 ();
        }

    }

    //Camera Switching

    public void SwitchToP1 () {
        P1Camera.SetActive (true);
        P2Camera.SetActive (false);
        BattleCamera.SetActive (false);

    }

    public void SwitchToP2 () {
        P1Camera.SetActive (false);
        P2Camera.SetActive (true);
        BattleCamera.SetActive (false);

    }

    public void SwitchToBattle () {
        P1Camera.SetActive (false);
        P2Camera.SetActive (false);
        BattleCamera.SetActive (true);
        BattleActive = true;

    }
}