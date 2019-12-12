using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatHelper : MonoBehaviour
{
    public GameObject statCanvas;
    public Text statText;
    public bool isSet = false;


    void Update()
    {
        statText.text =
        "CharacterName: " + gameObject.name + "\n" +
        "Class: " + gameObject.GetComponent<Character>().getClass() + "\n"+
        "Health: " + gameObject.GetComponent<Character>().getHealth() + "/" + gameObject.GetComponent<Character>().getHealthMax() + "          " + 
        "Armor: " + gameObject.GetComponent<Character>().getArmor() + "\n" +
        "Attack Speed: " + gameObject.GetComponent<Character>().getAttackSpeed() + "        " +
        "Resistance: " + gameObject.GetComponent<Character>().getResistance() + "\n" +
        "Attack Damage: " + gameObject.GetComponent<Character>().getAttackType() + "        " +
        "Attack Type: " + gameObject.GetComponent<Character>().getAttackType();
    }
    void OnMouseOver()
    {
        Debug.Log("Mouse Over Working");
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log ("right click");
            isSet = !isSet;
            statCanvas.SetActive (isSet);
        }
    }
}
