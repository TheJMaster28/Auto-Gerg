using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    // varibles all characers use
    [SerializeField]
    private float healthMax;

    [SerializeField]
    private float attackDamage;

    [SerializeField]
    private float defence;

    [SerializeField]
    private int range;

    [SerializeField]
    private float attackSpeed;

    public float health;



    // functions for awake and accessing stats
    private void Awake() {
        health = healthMax;
    }

    public float getAttackDamage() {
        return attackDamage;
    }

    public float getDefence() {
        return defence;
    }

    public int getRange() {
        return range;
    }

    public float getAttackSpeed() {
        return attackSpeed;
    }


}
