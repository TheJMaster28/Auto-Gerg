using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnClass : MonoBehaviour {

    public int BSynInc1 = 0;
    public int RSynInc1 = 0;
    public int GSynInc1 = 0;

    public int BSynInc2 = 0;
    public int RSynInc2 = 0;
    public int GSynInc2 = 0;

    public GameObject bladeMasterSelector;
    public GameObject rangerSelector;
    public GameObject gunslingerSelector;

    private GameObject linehandler;
    private Vector3 mousepos;


    // Start is called before the first frame update
    void Awake () {

        //GameObject.FindGameObjectWithTag("Blademaster_SynIcon_P1").GetComponent<Image>().color = new Color32(106, 106, 106, 255);
    }

    void Update () {

        /*USED FOR MOUSE POSTITION NOT IN USE NOW*/
        /*  mousepos = Input.mousePosition;
        mousepos.z = 10;
  

        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        */
        RangerSynergyActivate1();
        BladeMasterSynergyActivate1();
        GunslingerSynergyActivate1();

        RangerSynergyActivate2();
        BladeMasterSynergyActivate2();
        GunslingerSynergyActivate2();

    }

    public void spawnBlademaster () {
        Debug.Log ("Spawning bladeMaster");
        string objetName = bladeMasterSelector.GetComponent<CharacterChanger> ().imageName;
        GameObject b = Resources.Load (objetName) as GameObject;
        SpawnCharacter (b);
        //BSynInc++;
        //Debug.Log(BSynInc);
    }

    public void spawnGunslinger () {
        Debug.Log ("Spawning gunslinger");
        string objetName = gunslingerSelector.GetComponent<CharacterChanger> ().imageName;
        GameObject b = Resources.Load (objetName) as GameObject;
        SpawnCharacter (b);
        //GSynInc++;
        //Debug.Log(GSynInc);
    }

    public void spawnRanger () {
        Debug.Log ("Spawning ranger");
        string objetName = rangerSelector.GetComponent<CharacterChanger> ().imageName;
        GameObject b = Resources.Load (objetName) as GameObject;
        SpawnCharacter (b);
        //RSynInc++;
        //Debug.Log(RSynInc);

    }

    public void BladeMasterSynergyActivate2()
    {
        if (BSynInc2 > 1)
        {
            GameObject.FindGameObjectWithTag("Blademaster_SynIcon_P2").GetComponent<Image>().color = new Color32(250, 63, 63, 255);
        }

    }

    public void RangerSynergyActivate2()
    {
        if (RSynInc2 > 1)
        {
            GameObject.FindGameObjectWithTag("Ranger_SynIcon_P2").GetComponent<Image>().color = new Color32(31, 224, 54, 255);
        }

    }

    public void GunslingerSynergyActivate2()
    {
        if (GSynInc2 > 1)
        {
            GameObject.FindGameObjectWithTag("Gunslinger_SynIcon_P2").GetComponent<Image>().color = new Color32(243, 174, 106, 255);
        }

    }

    //END ACTIVATION OF P2 SYNERGY

    public void BladeMasterSynergyActivate1()
    {
        if (BSynInc1 > 1)
        {
            GameObject.FindGameObjectWithTag("Blademaster_SynIcon_P1").GetComponent<Image>().color = new Color32(250, 63, 63, 255); 
        }
       
    }

    public void RangerSynergyActivate1()
    {
        if (RSynInc1 > 1)
        {
            GameObject.FindGameObjectWithTag("Ranger_SynIcon_P1").GetComponent<Image>().color = new Color32(31, 224, 54, 255);
        }

    }

    public void GunslingerSynergyActivate1()
    {
        if (GSynInc1 > 1)
        {
            GameObject.FindGameObjectWithTag("Gunslinger_SynIcon_P1").GetComponent<Image>().color = new Color32(243,174,106, 255);
        }

    }


    private void SpawnCharacter (GameObject g) {
        bool P1CanSpawn = GameObject.FindGameObjectWithTag ("Player1").GetComponent<PlayerManager> ().getCanSpawn ();
        bool P2CanSpawn = GameObject.FindGameObjectWithTag ("Player2").GetComponent<PlayerManager> ().getCanSpawn ();

        GameObject P1 = GameObject.FindGameObjectWithTag ("Player1");
        GameObject P2 = GameObject.FindGameObjectWithTag ("Player2");

        if (P1CanSpawn == true) {
            //Spawn on player 1's side
            // may want to spawn on bench
            GameObject newGO = Instantiate (g, new Vector3 (0, 1, 0), Quaternion.identity);
            newGO.tag = "Player1";
            newGO.layer = 8; // 8 is Player1
            newGO.GetComponent<CharacterAI> ().enemyTag = "Player2";
            newGO.GetComponent<CharacterAI> ().enemyLayer = LayerMask.GetMask ("Player2");
            //RR: find a way to add to P1's P2's GameObject list
            P1.GetComponent<PlayerManager> ().addToActiveField (newGO);
            Debug.Log ("added blademaster to P1 active field list!");

            string obj1 = newGO.GetComponent<Character>().getClass();
            if (obj1 == "Blademaster") BSynInc1++; //player 1 blademaster syn increase 

            string obj2 = newGO.GetComponent<Character>().getClass();
            if (obj2 == "Ranger") RSynInc1++; //player 1 blademaster syn increase 

            string obj3 = newGO.GetComponent<Character>().getClass();
            if (obj2 == "Gunslinger") GSynInc1++; //player 1 blademaster syn increase 

        } else if (P2CanSpawn == true && P1CanSpawn == false) {
            //canSpawn is true for Player2
            GameObject newGO = Instantiate (g, new Vector3 (8, 1, 6), Quaternion.identity);
            newGO.tag = "Player2";
            newGO.layer = 9; // 9 is Player2
            newGO.GetComponent<CharacterAI> ().enemyTag = "Player1";
            newGO.GetComponent<CharacterAI> ().enemyLayer = LayerMask.GetMask ("Player1");
            P2.GetComponent<PlayerManager> ().addToActiveField (newGO);
            Debug.Log ("added blademaster to P2 active field list!");

            string obj4 = newGO.GetComponent<Character>().getClass();
            if (obj4 == "Blademaster") BSynInc2++; //player 1 blademaster syn increase 

            string obj5 = newGO.GetComponent<Character>().getClass();
            if (obj5 == "Ranger") RSynInc2++; //player 1 blademaster syn increase 

            string obj6 = newGO.GetComponent<Character>().getClass();
            if (obj6 == "Gunslinger") GSynInc2++; //player 1 blademaster syn increase 
        }

        //USED FOR MOUSE POSITION NOT IN USE NOW
        //linehandler = Instantiate(bladeMaster, mousepos, Quaternion.identity) as GameObject;
    }

}