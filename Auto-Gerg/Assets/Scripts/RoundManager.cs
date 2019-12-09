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

    private int bladeMasterSynCount;
    public int roundCount;

    public bool BattleCameraActive = false;

    public static float startBattleTimer = 15.0f;
    float currBattleTimer = startBattleTimer;

    // Start is called before the first frame update
    void Awake () {
        roundCount = 1;
    }

    // Update is called once per frame
    void Update () {
        if(P1.GetComponent<PlayerManager>().activeFieldMonsters.Count == roundCount && P1.GetComponent<PlayerManager>().GetHasEnded() == false) //player 1 hit max spawns for the round
        {
            if (P1.GetComponent<PlayerManager>().getCanSpawn() == false) { Debug.Log("P1 Max Spawn reached for the round"); } //change this to UI later
            P1.GetComponent<PlayerManager>().setCanSpawn(false);
        }

        if (P2.GetComponent<PlayerManager>().activeFieldMonsters.Count == roundCount && P2.GetComponent<PlayerManager>().GetHasEnded() == false) //player 2 hit max spawns for the round
        {
            if (P2.GetComponent<PlayerManager>().getCanSpawn() == false) { Debug.Log("P2 Max Spawn reached for the round"); } //change this to UI later
            P2.GetComponent<PlayerManager>().setCanSpawn(false);
        }

        //Timer to end battle for now
        if (BattleCamera.active == true) {
            currBattleTimer -= Time.deltaTime;
            Debug.Log ("Timer: " + currBattleTimer);
            if (currBattleTimer <= 0) {
                RoundReset ();
                CameraTurnManager ();
            }
        }

        //blademasterSynergy count
        bladeMasterSynCount = P1.GetComponent<PlayerManager> ().getBladeMasterSynergyCount ();

        if (bladeMasterSynCount > 1) {
            GameObject.FindGameObjectWithTag("Blademaster_Synergy").GetComponent<Image>().color = new Color32(233, 36, 21, 100);

        }
    }

    private void LateUpdate () {
        CameraTurnManager ();
    }

    //resets bool values for pre-round
    private void RoundReset () {

        P1.GetComponent<PlayerManager> ().resetPieces ();
        P2.GetComponent<PlayerManager> ().resetPieces ();

        P1.GetComponent<PlayerManager> ().SetWonRound (false);
        P1.GetComponent<PlayerManager> ().SetHasEnded (false);

        P2.GetComponent<PlayerManager> ().SetWonRound (false);
        P2.GetComponent<PlayerManager> ().SetHasEnded (false);

        roundCount++;
        currBattleTimer = startBattleTimer;
        BattleCameraActive = false;
    }

    public void CameraTurnManager () {

        bool p1HasEnded = P1.GetComponent<PlayerManager> ().GetHasEnded ();
        bool p2HasEnded = P2.GetComponent<PlayerManager> ().GetHasEnded ();

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
        BattleCameraActive = true;

    }
}