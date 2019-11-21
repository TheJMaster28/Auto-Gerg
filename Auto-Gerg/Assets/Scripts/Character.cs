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
	private float attackDamage;
	
	[SerializeField]
	private string attackType = "Physical";

    [SerializeField]
    private float armor;

    [SerializeField]
    private float resistance;

    [SerializeField]
    private int attackRange;

    [SerializeField]
    private float attackSpeed;

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
        return attackDamage;
    }
	public string getAttackType(){
		return attackType;
	}

    public float getArmor() {
        return armor;
    }
	
	public float getResistance(){
		return resistance;
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
