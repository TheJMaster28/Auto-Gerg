using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{


    // varibles all characters use
    [SerializeField]
    private float healthMax;

    public float health;

    [SerializeField]
    private float magicMax;

    [SerializeField]
    private float magic;

    [SerializeField]
    private float physicalAttack;

    [SerializeField]
    private float magicaAttack;

    [SerializeField]
    private float physicalDefence;

    [SerializeField]
    private float magicDefence;

    [SerializeField]
    private int attackRange;

    [SerializeField]
    private float attackSpeed;

    [SerializeField]
    private float critAttPercentage;

    [SerializeField]
    private float evasionPercentage;

    [SerializeField]
    private float healthRegenPercentage;


    // Tile positions
    public static Vector3 position;
    public static Vector3 baseSub = new Vector3(0f, -.5f, 0);
    public static Vector3 basePosition;



    public GameObject Tile;
    public bool isdead;

    // functions for awake and accessing stats
    private void Awake() {
        health = healthMax;
    }

    public float getAttackDamage() {
        return physicalAttack;
    }

    public float getDefence() {
        return physicalDefence;
    }

    public int getRange() {
        return attackRange;
    }

    public float getAttackSpeed() {
        return attackSpeed;
    }

    // Need to have this so I know the position for the piece at all times.
    public void Update()
    {
        position = this.transform.position;
        basePosition = position + baseSub;

        if ( health < 0  && !isdead ) {
            isdead = true;
            print("DEAD!!!!!");
            transform.position += new Vector3(0, -1f, 0);
        }
    }

}
