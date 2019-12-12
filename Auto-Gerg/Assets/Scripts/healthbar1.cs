using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar1 : MonoBehaviour {
    public Image HealthBar;
    // public Image HealthBar2;
    // public Image HealthBar3;
    // public Image HealthBar4;
    // public bool takeDamage;
    // public bool takeDamage2; 
    // public float health;
    // public float health2;
    // public Text dead;
    // public Text dead2;
    // public Text dead3;
    // public Text dead4;

    public GameObject player;

    // public GameObject otherPlayer;

    // Update is called once per frame
    void Update ()

    {

        float health = player.GetComponent<PlayerManager> ().getHealth ();
        // float health2 = otherPlayer.GetComponent<PlayerManager> ().getHealth ();
        HealthBar.fillAmount = (health) / (100);
        // HealthBar2.fillAmount = (health2) / (100);

        // if (takeDamage == true) {
        //     if (health > 0f) {
        //         health += -1.0f;
        //     }

        //     takeDamage = false;
        // }
        // if (takeDamage2 == true) {
        //     if (health2 > 0f) {
        //         health2 += -1.0f;
        //     }

        //     takeDamage2 = false;
        // }

    }
}