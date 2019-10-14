using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Unit
{
   

    public void WiazrdAOE()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        int random = 0;

        random = Random.Range(0, 2);

        hP = 120;
        maxHP = hP;
        attack = 6;
        attackRange = 1;
        speed = 1;
        name = "Mage";
        isAttacking = false;
        team = "Neutral";
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
