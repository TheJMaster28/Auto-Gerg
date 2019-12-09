using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnClass : MonoBehaviour {

    public int BSynInc = 0;
    public GameObject bladeMasterSelector;
    public GameObject rangerSelector;
    public GameObject gunslingerSelector;

    private GameObject linehandler;
    private Vector3 mousepos;


    // Start is called before the first frame update
    void Awake () {

    }

    void Update () {

        /*USED FOR MOUSE POSTITION NOT IN USE NOW*/
        /*  mousepos = Input.mousePosition;
        mousepos.z = 10;
  

        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        */
        BladeMasterSynergyActivate();

    }

    public void spawnBlademaster () {
        Debug.Log ("Spawning bladeMaster");
        string objetName = bladeMasterSelector.GetComponent<CharacterChanger> ().imageName;
        GameObject b = Resources.Load (objetName) as GameObject;
        SpawnCharacter (b);
    }

    public void spawnGunslinger () {
        Debug.Log ("Spawning gunslinger");
        string objetName = gunslingerSelector.GetComponent<CharacterChanger> ().imageName;
        GameObject b = Resources.Load (objetName) as GameObject;
        SpawnCharacter (b);

    }

    public void spawnRanger () {
        Debug.Log ("Spawning ranger");
        string objetName = rangerSelector.GetComponent<CharacterChanger> ().imageName;
        GameObject b = Resources.Load (objetName) as GameObject;
        SpawnCharacter (b);

    }

    public void BladeMasterSynergyActivate()
    {
        if (BSynInc > 2)
        {
            GameObject.FindGameObjectWithTag("Blademaster_SynIcon_P1").GetComponent<Image>().color = new Color32(1, 1, 1, 0); 
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

        } else if (P2CanSpawn == true && P1CanSpawn == false) {
            //canSpawn is true for Player2
            GameObject newGO = Instantiate (g, new Vector3 (8, 1, 6), Quaternion.identity);
            newGO.tag = "Player2";
            newGO.layer = 9; // 9 is Player2
            newGO.GetComponent<CharacterAI> ().enemyTag = "Player1";
            newGO.GetComponent<CharacterAI> ().enemyLayer = LayerMask.GetMask ("Player1");
            P2.GetComponent<PlayerManager> ().addToActiveField (newGO);
            Debug.Log ("added blademaster to P2 active field list!");
        }

        //USED FOR MOUSE POSITION NOT IN USE NOW
        //linehandler = Instantiate(bladeMaster, mousepos, Quaternion.identity) as GameObject;
    }

}