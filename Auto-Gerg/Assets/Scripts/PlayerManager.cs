﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject Player;
    public LinkedList<GameObject> activeField = new LinkedList<GameObject>();
    public LinkedList<GameObject> benched = new LinkedList<GameObject>();

    

    //defaults
    private float Health = 100.0f;
    private bool hasWonRound = false;
    public bool canSpawn = true;
    public bool hasEnded = false;
    private int bladeMasterSynergyCount = 5;


    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canSpawn) Debug.Log("Cannot Spawn");
    }


    public void SetWonRound(bool wr)
    {
        hasWonRound = wr;
    }

    public bool GetWonRound()
    {
        return hasWonRound;
    }

    public void SetHasEnded(bool hg)
    {
        hasEnded = hg;
    }

    public bool GetHasEnded()
    {
        return hasEnded;
    }

    public void TakeDamage(int takeDmg)
    {
        Health = Health - takeDmg;
    }

    public int getBladeMasterSynergyCount()
    {
        return bladeMasterSynergyCount;
    }

    public void setCanSpawn(bool s)
    {
        canSpawn = s;
    }

    public bool getCanSpawn()
    {
        return canSpawn;
    }

}
