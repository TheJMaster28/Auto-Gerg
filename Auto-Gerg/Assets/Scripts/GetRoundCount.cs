using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRoundCount : MonoBehaviour {

    GameObject rm;
    // Update is called once per frame
    void Update () {
        rm = GameObject.FindGameObjectWithTag ("RoundManager");
        GetComponent<Text> ().text = "Round Count: " + rm.GetComponent<RoundManager> ().roundCount;
    }
}