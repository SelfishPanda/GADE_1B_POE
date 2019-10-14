using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Unit
{

    public MeleeUnit(int hp, int attack, int attackRange, int speed, string name, string team, bool isAttacking) : base(hp, attack, attackRange, speed, name, team, isAttacking)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        hP = 80;
        attack = 5;
        attackRange = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Unit[] Units = GameObject.FindObjectsOfType<Unit>();
        Unit closestUnit = ClosestUnit(Units); ;


        if (!this.InAttackRange(closestUnit))
        {
            Movement(closestUnit);
        }
        else
        {
            Combat(closestUnit);
        }
        
    }

   

}
