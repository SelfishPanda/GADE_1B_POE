﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Unit
{
   

   

    // Start is called before the first frame update
    void Start()
    {
        int random = 0;

        random = Random.Range(0, 2);

        hP = 1000;
        maxHP = hP;
        attack = 9;
        attackRange = 1;
        speed = 2;
        name = "Mage";
        isAttacking = false;
        team = "Neutral";
       
    }

   
}
