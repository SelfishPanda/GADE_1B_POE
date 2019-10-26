using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    [SerializeField] GameObject[] options = new GameObject[5];
    
    [SerializeField] static int MIN_X = 0, MAX_X = 20, MIN_Y = 0, MAX_Y = 20, UNITS_5;


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

    void CreateUnit()
    {
        GameObject unit = Instantiate(options[Random.Range(0,5)]);
        unit.transform.position = new Vector3(Random.Range(MIN_X,MAX_X),0, Random.Range(MIN_Y, MAX_Y));       
    }
}
