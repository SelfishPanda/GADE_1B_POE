using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Unit
{

   

    [SerializeField]
    GameObject gameObj = new GameObject();

    // Start is called before the first frame update
    void Start()
    {
        int random = 0;

        random = Random.Range(0, 2);

        hP = 80;
        maxHP = hP;
        attack = 5;
        attackRange = 1;
        speed = 1;
        name = "Knight";
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


       
    if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(gameObj, new Vector3(0,0,0),Quaternion.identity);
        }
    }

   

}
