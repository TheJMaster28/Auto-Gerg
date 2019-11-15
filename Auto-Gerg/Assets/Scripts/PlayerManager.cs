using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject Player;

    //defaults
    private float Health = 100.0f;
    
    private bool hasWonRound = false;
    public bool hasEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetWonRound(bool wr)
    {
        hasWonRound = wr;
    }

    public bool GetWonRound()
    {
        return hasWonRound;
    }

    public void SetHasGone(bool hg)
    {
        hasEnded = hg;
    }

    public bool GetHasGone()
    {
        return hasEnded;
    }

    public void TakeDamage(int takeDmg)
    {
        Health = Health - takeDmg;
    }
}
