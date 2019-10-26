using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected int hP;
    protected int maxHP;
    protected string team;
   

   

    public int HP { get => hP; set => hP = value; }
    public int MaxHP { get => maxHP;}
    public string Team { get => team;}

    public bool Death()
    {//checks to see if this unit is dead
        bool death;
        death = false;

        if (HP <= 0)
        {
            death = true;
            HP = 0;
        }

        return death;

    }
    

    public abstract string toString();

    
}

