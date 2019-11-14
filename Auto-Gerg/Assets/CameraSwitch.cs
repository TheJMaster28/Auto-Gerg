using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public GameObject P1Camera;
    public GameObject P2Camera;
    public GameObject BattleCamera;

    // Start is called before the first frame update
    void Start()
    {
        /*
         * RR: For Testing purposes P1 Camera will start as active
         *     Switch Order (for now): P1, P2, Battle, Repeat
         */
        P1Camera.SetActive(true);
        P2Camera.SetActive(false);
        BattleCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
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

    }

}
