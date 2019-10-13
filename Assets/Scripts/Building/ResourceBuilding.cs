using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuilding : Building
{
    protected string resourceType;
    protected int resourcesGenerated;
    protected int resourcesGeneratedPerRound;
    protected int resourcePool;

    public ResourceBuilding(int hP, string team, string resourceType, int resourcesGenerated, int resourcesGeneratedPerRound, int resourcePool) : base(hP,team)
    {
        this.resourceType = resourceType;
        this.resourcesGenerated = 0;
        this.resourcesGeneratedPerRound = resourcesGeneratedPerRound;
        this.resourcePool = resourcePool;
    }

    public string ResourceType { get => resourceType; set => resourceType = value; }
    public int ResourcesGenerated { get => resourcesGenerated; set => resourcesGenerated = value; }
    public int ResourcesGeneratedPerRound { get => resourcesGeneratedPerRound; set => resourcesGeneratedPerRound = value; }
    public int ResourcePool { get => resourcePool; set => resourcePool = value; }

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
        output = "Resource Building (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + transform.position.x + "\n" + "Y-Position :" + transform.position.y + "\n" + "Resources Generated :" + this.resourcesGenerated + "\n" + "Resources Left in Pool :" + this.resourcePool;
        return output;
    }
}
