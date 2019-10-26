using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    [SerializeField] GameObject[] options = new GameObject[9];
    
    [SerializeField] static int MIN_X = 0, MAX_X = 50, MIN_Y = 0, MAX_Y = 50, UNITS_20;

    public int t1Resources = 0;
    public int t2Resources = 0;
    void Start()
    {
        int UnitAmount = 7;

        for (int i = 0; i < UnitAmount; i++)
        {
            CreateUnit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FactoryCreate(int type, string team)
    {
        GameObject unit = Instantiate(options[Random.Range(0, 9)]);
        unit.transform.position = new Vector3(Random.Range(MIN_X, MAX_X), 0, Random.Range(MIN_Y, MAX_Y));
        t1Resources = 0;
        t2Resources = 0;
    }

    void CreateUnit()
    {
        GameObject unit = Instantiate(options[Random.Range(0,9)]);
        unit.transform.position = new Vector3(Random.Range(MIN_X,MAX_X),0, Random.Range(MIN_Y, MAX_Y));       
    }
}
