using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar1 : MonoBehaviour
{
    public Image HealthBar;
    public Image HealthBar2;
    public bool takeDamage;
    public bool takeDamage2;
    public float health=100;
    public float health2 =100;
    public Text dead;
    public Text dead2;
    // Update is called once per frame
    void Update()

    {
        HealthBar.fillAmount = (health) / (100);
        HealthBar2.fillAmount = (health2) / (100);
        if (takeDamage == true)
        {
            if (health > 0f)
            {
                health += -1.0f;
            }
            if (health == 0)
            {
                dead.text = "are dead";
            }
            else
            {
                dead.text = "";
            }
        }
        if (takeDamage2 == true)
        {
            if (health2 > 0f)
            {
                health2 += -1.0f;
            }
            if (health2 == 0)
            {
                dead2.text = "is dead";
            }
            else
            {
                dead2.text = "";
            }
        }
    }
}
