using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    [SerializeField] GameObject[] options = new GameObject[9];
    
    [SerializeField] static int MIN_X = 0, MAX_X = 80, MIN_Y = 0, MAX_Y = 80, UNITS = 20;

    public int t1Resources = 0;
    public int t2Resources = 0;
    void Start()
    {
        int UnitAmount = UNITS;

        for (int i = 0; i < UnitAmount; i++)
        {
            CreateUnit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FactoryCreate(int type, string team, Vector3 spawnPos)
    {
        if (team == "Team 1")
        {
            if (type == 1)
            {
                GameObject spawn = Instantiate(options[0]);
                spawn.transform.position = spawnPos;
            }
            else
            {
                GameObject spawn = Instantiate(options[2]);
                spawn.transform.position = spawnPos;
            }
            t1Resources = 0;
        }
        else
        {
            if (type == 1)
            {
                GameObject spawn = Instantiate(options[1]);
                spawn.transform.position = spawnPos;
            }
            else
            {
                GameObject spawn = Instantiate(options[3]);
                spawn.transform.position = spawnPos;
            }
            t2Resources = 0;
        }
       
       

       
    }

    void CreateUnit()
    {
        GameObject unit = Instantiate(options[Random.Range(0,9)]);
        unit.transform.position = new Vector3(Random.Range(MIN_X,MAX_X),0, Random.Range(MIN_Y, MAX_Y));       
    }
}
