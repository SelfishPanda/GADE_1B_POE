using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuilding : Building
{
    protected string resourceType;
    protected int resourcesGenerated;
    protected int resourcesGeneratedPerRound;
    protected int resourcePool;
    GameEngine gameEngine;
  
    // Start is called before the first frame update
    void Start()
    {
        gameEngine = GameObject.FindObjectOfType<GameEngine>();
        hP = 3000;
        maxHP = 2000;
        resourceType = "Adamantium";
        resourcesGeneratedPerRound = 1;
        resourcesGenerated = 0;
        resourcePool = 1000000;

        if (this.gameObject.tag == "Team 1")
        {
            team = "Team 1";
        }
        else
        {
            team = "Team 2";
        }
    }

    public string ResourceType { get => resourceType; set => resourceType = value; }
    public int ResourcesGenerated { get => resourcesGenerated; set => resourcesGenerated = value; }
    public int ResourcesGeneratedPerRound { get => resourcesGeneratedPerRound; set => resourcesGeneratedPerRound = value; }
    public int ResourcePool { get => resourcePool; set => resourcePool = value; }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            if (ResourcePool <= 0 )
            {
                Destroy(gameObject);
            }
            else
            {
                if (Team == "Team 1")
                {
                    gameEngine.t1Resources += resourcesGeneratedPerRound;
                    ResourcePool -= resourcesGeneratedPerRound;
                }
                else
                {
                    gameEngine.t2Resources += resourcesGeneratedPerRound;
                    ResourcePool -= resourcesGeneratedPerRound;
                }
               
            }
        }
    }


    public override string toString()
    {//Puts all the units stats into a string so it can be output to display them
        string output = "";
        output = "Resource Building (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + transform.position.x + "\n" + "Y-Position :" + transform.position.y + "\n" + "Resources Generated :" + this.resourcesGenerated + "\n" + "Resources Left in Pool :" + this.resourcePool;
        return output;
    }
}
