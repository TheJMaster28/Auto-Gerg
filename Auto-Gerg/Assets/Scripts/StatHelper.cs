using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatHelper : MonoBehaviour
{
    public GameObject statCanvas;
    public Text charName;
    public Text statLeft;
    public Text statRight;


    void Update()
    {
        //enter character name and class into first text box
        charName.text =
        "Character Name: " + gameObject.name.Substring(0,gameObject.name.IndexOf("(")) + "\n" +
        "Class: " + gameObject.GetComponent<Character>().getClass() + "\n";
        
        //enter character health, attack speed, and damage into left text box
        statLeft.text =
        "Health: " + gameObject.GetComponent<Character>().getHealth() + "/" + gameObject.GetComponent<Character>().getHealthMax() + "\n" +
        "Attack Speed: " + gameObject.GetComponent<Character>().getAttackSpeed() + "\n" +
        "Attack Damage: " + gameObject.GetComponent<Character>().getAttackDamage();

        //enter character armor, resistance, and attack type to right text box
        statRight.text =
        "Armor: " + gameObject.GetComponent<Character>().getArmor() + "\n" +
        "Resistance: " + gameObject.GetComponent<Character>().getResistance() + "\n" +
        "Attack Type: " + gameObject.GetComponent<Character>().getAttackType();
        //statText.text = statText.text.Substring(0,statText.text.IndexOf("(")) + statText.text.Substring(statText.text.IndexOf(")"),statText.text.Length-1);
    }
    void OnMouseOver()
    {
        Debug.Log("Mouse Over Working");
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log ("right click");
            statCanvas.SetActive (true);
        }
    }
    void OnMouseExit()
    {
        statCanvas.SetActive(false);
    }
}
