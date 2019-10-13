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

    protected Unit(int hp, int attack, int attackRange, int speed, string name, string team, bool isAttacking)
    {
        this.hP = hp;
        maxHP = hp;
        this.attack = attack;
        this.attackRange = attackRange;
        this.speed = speed;
        this.name = name;
        this.team = team;
        this.isAttacking = isAttacking;
    }

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


    public Unit ClosestUnit()
    {
        return null;
    }


    public bool InAttackRange()
    {
        return false;
    }


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


    public void Movement()
    {

    }


    public override string ToString()
    {
        string output = "";
        output = this.Name+" (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + transform.position.x + "\n" + "Y-Position :" + transform.position.y;
        return output;
    }
}
