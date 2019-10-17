using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected int hP;
    protected int maxHP;
    protected int attack;
    protected int attackRange;
    protected int speed;
    protected string name;
    protected string team;
    protected bool isAttacking;


    public int HP { get => hP; set => hP = value; }
    public int MaxHP { get => maxHP;}
    public int Attack { get => attack;}
    public int AttackRange { get => attackRange;}
    public int Speed { get => speed;}
    public string Name { get => name;}
    public string Team { get => team;}
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }


    public bool Death()
    {
        bool dead;
        if (this.HP <= 0)
        {
            dead = true;
        }
        else
        {
            dead = false;
        }
        return dead;
    }

    //ClosestUnit
     public Unit ClosestUnit(Unit[] units)
     {
        float closestDist = int.MaxValue;
        float distance = 0;
        Unit Closestunit = null;
        Debug.Log(units.Length);
        foreach (Unit unit in units)
         {
            Debug.Log(unit.Name);
                 distance = Vector3.Distance(transform.position,unit.transform.position);
                 if (distance < closestDist)
                 {
                     closestDist = distance;
                     Closestunit = unit;
                 }             
         }        
        Debug.Log(Closestunit.ToString());
         Debug.DrawLine(this.transform.position, Closestunit.transform.position);
         return Closestunit;       
     }
    public Building ClosestUnit(Building[] units)
    {
        float closestDist = int.MaxValue;
        Building Closestunit = null;
        foreach (Building unit in units)
        {           
                float distance = Vector3.Distance(this.transform.position, unit.transform.position);
                if (distance < closestDist)
                {
                    closestDist = distance;
                    Closestunit = unit;
                }            
        }
        Debug.Log(Closestunit.transform.position);
        Debug.DrawLine(this.transform.position, Closestunit.transform.position);
        return Closestunit;
    }





    //AttackRange
    public bool InAttackRange(Unit Enemy)
    {
        if (Vector3.Distance(this.transform.position, Enemy.transform.position) <= this.AttackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
      
    }
    public bool InAttackRange(Building Enemy)
    {
        if (Vector3.Distance(this.transform.position, Enemy.transform.position) <= this.AttackRange)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    //Combat
    public void Combat(Unit Enemy)
    {
        if (Enemy.Death())
        {}
        else if (isAttacking == true)
        {
            Enemy.HP = Enemy.HP - this.attack;
        }
    }
    public void Combat(Building Enemy)
    {
        if (Enemy.Death())
        { }
        else if (isAttacking == true)
        {
            Enemy.HP = Enemy.HP - this.attack;
        }
        
    }

    //Movement to enemy
    public void Movement(Unit Enemy)
    {
        transform.position = Vector3.MoveTowards(this.transform.position, Enemy.transform.position, this.Speed*Time.deltaTime);
    }
    public void Movement(Building Enemy)
    {
        transform.position = Vector3.MoveTowards(this.transform.position, Enemy.transform.position, this.Speed * Time.deltaTime);
    }


    public override string ToString()
    {
        string output = "";
        output = this.Name+" (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + transform.position.x + "\n" + "Y-Position :" + transform.position.y;
        return output;
    }  

    public Unit[] EnemyUnits(Unit[] Units)
    {
        Unit[] enemyUnits = new Unit[0];

        for (int i = 0; i < Units.Length; i++)
        {
            if (this.Team == "Team 2")
            {
                if (Units[i].Team == "Team 1")
                {
                    System.Array.Resize(ref enemyUnits, enemyUnits.Length+1);
                    enemyUnits[enemyUnits.Length-1] = Units[i]; 
                    
                }
            }
            if (this.Team == "Team 1")
            {
                if (Units[i].Team == "Team 2")
                {
                    System.Array.Resize(ref enemyUnits, enemyUnits.Length + 1);
                    enemyUnits[enemyUnits.Length - 1] = Units[i];
                }
            }

        }
        return enemyUnits;
    }

}
