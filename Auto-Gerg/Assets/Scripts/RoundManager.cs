﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    public GameObject P1Camera;
    public GameObject P2Camera;
    public GameObject P1;
    public GameObject P2;
    public GameObject BattleCamera;

    public bool BattleCameraActive = false;

    private int roundCount = 0;

    public static float startBattleTimer = 15.0f;
    float currBattleTimer = startBattleTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //Timer to end battle for now
        if (BattleCamera.active == true)
        {
            currBattleTimer -= Time.deltaTime;
            Debug.Log("Timer: " + currBattleTimer);
            if (currBattleTimer <= 0)
            {
                RoundReset();
                CameraTurnManager();
            }
        }
    }

    private void LateUpdate()
    {
        CameraTurnManager();
    }


    //resets bool values for pre-round
    private void RoundReset()
    {
        P1.GetComponent<PlayerManager>().SetWonRound(false);
        P1.GetComponent<PlayerManager>().SetHasGone(false);
        P2.GetComponent<PlayerManager>().SetWonRound(false);
        P2.GetComponent<PlayerManager>().SetHasGone(false);

        currBattleTimer = startBattleTimer;
        BattleCameraActive = false;
    }

    

    public void CameraTurnManager()
    {

        bool p1HasEnded = P1.GetComponent<PlayerManager>().GetHasGone();
        bool p2HasEnded = P2.GetComponent<PlayerManager>().GetHasGone();

        //Player 1 hasGone Player 2 has not, switch to Player 2 Cam
        if (p1HasEnded == true && p2HasEnded == false)
        {
            SwitchToP2();
        }
        //Player 2 hasGone Player 1 has not, switch to Player 1 Cam
        else if (p1HasEnded == false && p2HasEnded == true )
        {
            SwitchToP1();
        }
        //Both players have ended their turn, switch to battle
        else if(p1HasEnded = true && p2HasEnded == true)
        {
            SwitchToBattle();
        }
        //default to player 1 for now
        else
        {
            SwitchToP1();
        }

        
    }

    //Camera Switching

    public void SwitchToP1()
    {
        P1Camera.SetActive(true);
        P2Camera.SetActive(false);
        BattleCamera.SetActive(false);

    }

    public void SwitchToP2()
    {
        P1Camera.SetActive(false);
        P2Camera.SetActive(true);
        BattleCamera.SetActive(false);

    }

    public void SwitchToBattle()
    {
        P1Camera.SetActive(false);
        P2Camera.SetActive(false);
        BattleCamera.SetActive(true);
        BattleCameraActive = true;
        
    }
}