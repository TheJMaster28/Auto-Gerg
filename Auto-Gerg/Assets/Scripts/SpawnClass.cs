using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClass : MonoBehaviour
{

    public GameObject bladeMaster;
    public GameObject Ranger;
    public GameObject Gunslinger;
    public Transform objectToMove;
 

    // Start is called before the first frame update
    void Start()
    {
       

    }

    void Update()
    {
        
    }

    public void spawnBlademaster()
    {
        bool P1CanSpawn = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerManager>().getCanSpawn();
        bool P2CanSpawn = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerManager>().getCanSpawn();

        Debug.Log("Spawning bladeMaster");
        if(P1CanSpawn == true)
        {
            //Spawn on player 1's side
            Instantiate(bladeMaster, new Vector3(0, 1, 0), Quaternion.identity);
        } else if(P2CanSpawn == true)
        {
            //canSpawn is true for Player2
            Instantiate(bladeMaster, new Vector3(8, 1 , 6), Quaternion.identity);
        }
        
        

   
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
