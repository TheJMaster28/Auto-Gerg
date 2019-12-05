using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClass : MonoBehaviour
{

    public GameObject bladeMaster;
    public GameObject Ranger;
    public GameObject Gunslinger;
  
    private GameObject linehandler;
    private Vector3 mousepos;
 
    

    // Start is called before the first frame update
    void Awake()
    {
        
    }

  

    void Update()
    {

        /*USED FOR MOUSE POSTITION NOT IN USE NOW*/
      /*  mousepos = Input.mousePosition;
        mousepos.z = 10;
  

        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        */

    }

    public void spawnBlademaster()
    {
        bool P1CanSpawn = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerManager>().getCanSpawn();
        bool P2CanSpawn = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerManager>().getCanSpawn();

        GameObject P1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject P2 = GameObject.FindGameObjectWithTag("Player2");


        Debug.Log("Spawning bladeMaster");
        if(P1CanSpawn == true )
        {
            //Spawn on player 1's side
            GameObject newGO = Instantiate(bladeMaster, new Vector3(0, 1, 0), Quaternion.identity);

            //RR: find a way to add to P1's P2's GameObject list
            P1.GetComponent<PlayerManager>().addToActiveField(newGO);
            Debug.Log("added blademaster to P1 active field list!");

        } else if(P2CanSpawn == true && P1CanSpawn == false)
        {
            //canSpawn is true for Player2
            GameObject newGO = Instantiate(bladeMaster, new Vector3(8, 1 , 6), Quaternion.identity);
            P2.GetComponent<PlayerManager>().addToActiveField(newGO);
            Debug.Log("added blademaster to P2 active field list!");
        }
        
        


     //USED FOR MOUSE POSITION NOT IN USE NOW
            //linehandler = Instantiate(bladeMaster, mousepos, Quaternion.identity) as GameObject;




    }

    public void spawnGunslinger()
    {
        Debug.Log("Spawning gunslinger");
        Instantiate(Gunslinger, new Vector3(0, 1, 0), Quaternion.identity);

    }

    public void spawnRanger()
    {
        Debug.Log("Spawning ranger");
        Instantiate(Ranger, new Vector3(0, 1, 0), Quaternion.identity);

    }

}
