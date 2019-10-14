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
            
        hP = 60;
        maxHP = hP;
        attack = 7;
        attackRange = 2;
        speed = 1;
        name = "Archer";
        isAttacking = false;

        if (random == 0)
        {
            team = "Team 1";
        }
        else
        {
            team = "Team 2";
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
