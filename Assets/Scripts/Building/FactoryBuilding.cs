using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuilding : Building
{
    protected string unitToProduce;
    protected int productionSpeed;
    protected int spawnYPos;
    protected int unitsProduced;

    public FactoryBuilding(int hP, string team,string unitToProduce, int productionSpeed, int spawnYPos) : base(hP, team)
    {
        this.unitToProduce = unitToProduce;
        this.productionSpeed = productionSpeed;
        this.spawnYPos = spawnYPos;
        this.unitsProduced = 0;
    }

    public string UnitToProduce { get => unitToProduce;}
    public int ProductionSpeed { get => productionSpeed;}
    public int SpawnYPos { get => spawnYPos;}
    public int UnitsProduced { get => unitsProduced; set => unitsProduced = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public override string toString()
    {//Puts all the units stats into a string so it can be output to display them
        string output = "";
        output = "Factory Building (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + transform.position.x + "\n" + "Y-Position :" + transform.position.y + "\n" + "Units Produced :" + this.unitsProduced + "\n" + "Units Being Produced :" + this.unitToProduce;
        return output;

    }
}
