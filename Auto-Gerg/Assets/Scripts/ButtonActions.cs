using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{

  
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTurn()
    {
        //set player's isTurn to false when they click on the end turn button
        player.GetComponent<PlayerManager>().SetHasEnded(true);
        player.GetComponent<PlayerManager>().setCanSpawn(false);
        
    }
    
    

}
