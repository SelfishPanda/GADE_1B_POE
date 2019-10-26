using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryBuilding : Building
{
    protected int unitToProduce;
    protected int productionSpeed;
    public Vector3 spawnYPos;
    protected int unitsProduced;
    private bool spawned;
    [SerializeField] public Image healthBar;
    GameEngine gameEngine;






    // Start is called before the first frame update
    void Start()
    {

        gameEngine = GameObject.FindObjectOfType<GameEngine>();
        hP = 3000;
        maxHP = 2000;
        this.productionSpeed = 400;
        spawnYPos = new Vector3(transform.position.x,0,transform.position.z-1);
        unitToProduce = Random.Range(0, 2);
        this.unitsProduced = 0;

        if (this.gameObject.tag == "Team 1")
        {
            team = "Team 1";
        }
        else
        {
            team = "Team 2";
        }

    }

    public int UnitToProduce { get => unitToProduce; }
    public int ProductionSpeed { get => productionSpeed; }
    public int UnitsProduced { get => unitsProduced; set => unitsProduced = value; }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        if (Team == "Team 1")
        {
            if (gameEngine.t1Resources >= ProductionSpeed)
            {
                if (spawned)
                {
                    spawned = false;
                }
                else
                {
                    gameEngine.FactoryCreate(unitToProduce, Team, spawnYPos);
                    spawned = true;
                }
               
            }
        }
        else
        {
            if (gameEngine.t2Resources >= ProductionSpeed)
            {
                if (spawned)
                {
                    spawned = false;
                }
                else
                {
                    gameEngine.FactoryCreate(unitToProduce, Team, spawnYPos);
                    spawned = true;
                }
            }
        }
        healthBar = GetComponentsInChildren<Image>()[1];
        healthBar.fillAmount = (float)HP / MaxHP;
    }



    public override string toString()
    {//Puts all the units stats into a string so it can be output to display them
        string output = "";
        output = "Factory Building (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + transform.position.x + "\n" + "Y-Position :" + transform.position.y + "\n" + "Units Produced :" + this.unitsProduced + "\n" + "Units Being Produced :" + this.unitToProduce;
        return output;

    }
}
