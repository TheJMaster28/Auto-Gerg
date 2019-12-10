using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatMenuPopup : MonoBehaviour {
    //private bool showText = false;
    //public Text displayText;
    private Character characterScript;
    private float healthMax;
    private float health;
    private float attackDamage;
    private string attackType;
    private float armor;
    private float resistance;
    private int attackRange;
    private float attackSpeed;
    private string charClass;
    private string charRace;
    public string stats;
    private void Awake () {
        characterScript = GetComponent<Character> ();
        healthMax = characterScript.getHealthMax ();
        health = characterScript.getHealth ();
        attackDamage = characterScript.getAttackDamage ();
        attackType = characterScript.getAttackType ();
        armor = characterScript.getArmor ();
        resistance = characterScript.getResistance ();
        attackRange = characterScript.getRange ();
        attackSpeed = characterScript.getAttackSpeed ();
        charClass = characterScript.getClass ();
        charRace = characterScript.getRace ();
        stats = "Class:" + characterScript.getClass () +
            "Health:" + health + "/" + healthMax +
            "\n";

    }

    void onMouseDown () {

    }

    /*    void onGUI()
     *    {
     *        if(showText)
     *        {
     *            displayText.text = "hello";
     *
     *            if(GUI.Button(new Rect(100,100,100,20), "Click To Close"))
     *                 // If you click this button, set showText to false
     *                 showText = false;
     *        }
     *    }
     */
}