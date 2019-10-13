using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected int hP;
    protected int maxHP;
    protected string team;  

    public Building(int hP, int maxHP, string team)
    {
        this.hP = hP;
        this.maxHP = maxHP;
        this.team = team;
    }

    public int HP { get => hP; set => hP = value; }
    public int MaxHP { get => maxHP;}
    public string Team { get => team;}

    public abstract bool Death();
    public abstract string toString();
}

