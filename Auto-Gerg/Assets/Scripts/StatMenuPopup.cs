using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatMenuPopup : MonoBehaviour
{
    //private bool showText = false;
    //public Text displayText;
    private float healthMax = characterScript.getHealthMax();
    private float health = characterScript.health();
    private float attackDamage = characterScript.getAttackDamage();
    private string attackType = characterScript.getAttackType();
    private float armor = characterScript.getArmor();
    private float resistance = characterScript.getResistance();
    private int attackRange = characterScript.getAttackRange();
    private float attackSpeed = characterScript.getAttackSpeed();
    private string charClass = characterScript.getClass();
    private string charRace = characterScript.getRace();
    public string stats =   "Class:" + characterScript.getClass() +
                            "Health:" + health + "/"+ healthMax +
                            "\n";
    void onMouseDown()
    {
        
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
