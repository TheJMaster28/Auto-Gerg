using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

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

    [SerializeField]
    private string charClass;

    [SerializeField]
    private string charRace;

    // Tile positions
    public static Vector3 position;
    public static Vector3 baseSub = new Vector3 (0f, -.5f, 0);
    public static Vector3 basePosition;

    public bool isMoving = false;

    public GameObject Tile;
    public bool isdead = false;

    public AudioClip deathSound;

    public AudioClip attackSound;

    private AudioSource s;

    // functions for awake and accessing stats
    private void Awake () {
        health = healthMax;
        s = GetComponent<AudioSource> ();
    }

    public bool getIsDead () {
        return isdead;
    }
    public float getHealthMax () {
        return healthMax;
    }
    public float getHealth () {
        return health;
    }
    public float getAttackDamage () {
        return attackDamage;
    }
    public string getAttackType () {
        return attackType;
    }

    public float getArmor () {
        return armor;
    }

    public float getResistance () {
        return resistance;
    }

    public int getRange () {
        return attackRange;
    }

    public float getAttackSpeed () {
        return attackSpeed;
    }

    public string getClass () {
        return charClass;
    }

    public string getRace () {
        return charRace;
    }

    public void revertHealth () {
        health = healthMax;
        isdead = false;
        // isMoving = false;

    }

    public void setIsDead (bool d) {
        isdead = d;
    }

    public void playAttack () {
        s.clip = attackSound;
        s.Play ();
    }

    // Need to have this so I know the position for the piece at all times.
    public void Update () {
        position = this.transform.position;
        basePosition = position + baseSub;

        if (health < 0 && !isdead) {
            isdead = true;
            Tile.GetComponent<GroundTiles> ().chessPiece = null;
            s.clip = deathSound;
            s.Play ();
            print ("DEAD!!!!!");
            transform.position += new Vector3 (0, -1f, 0);
        }
    }

}