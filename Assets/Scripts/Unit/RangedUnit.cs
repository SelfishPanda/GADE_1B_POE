using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RangedUnit : Unit
{
    

   

    // Start is called before the first frame update
    void Start()
    {       
        int random = 0;

        random = Random.Range(0, 2);
            
        hP = 600;
        maxHP = hP;
        attack = 2;
        attackRange = 2;
        speed = 1;
        name = "Archer";
        isAttacking = false;
        

        if (this.gameObject.tag == "Team 1")
        {
            team = "Team 1";
        }
        else
        {
            team = "Team 2";
        }

    }

   
}
