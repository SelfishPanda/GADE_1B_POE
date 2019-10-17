using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeUnit : Unit
{


    [SerializeField] Unit[] thing;
   

    // Start is called before the first frame update
    void Start()
    {
        int random = 0;

        random = Random.Range(0, 2);

        hP = 80;
        maxHP = hP;
        attack = 5;
        attackRange = 1;
        speed = 2;
        name = "Knight";
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

    // Update is called once per frame
    void Update()
    {
        Unit[] Units;        
        Units = GameObject.FindObjectsOfType<Unit>();                
        
        Unit[] EnemyUnits;
        EnemyUnits = this.EnemyUnits(Units);
        thing = EnemyUnits;
        Unit closestUnit = ClosestUnit(EnemyUnits);
        bool attacking = this.InAttackRange(closestUnit);

        if (!attacking)
        {
            Movement(closestUnit);
        }
        else
        {
            Combat(closestUnit);
        }





    }

}
