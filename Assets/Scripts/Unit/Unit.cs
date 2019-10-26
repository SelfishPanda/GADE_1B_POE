using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] public Image healthBar;
    

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
            this.HP = 0;
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
       
        foreach (Unit unit in units)
        {

            distance = Vector3.Distance(transform.position, unit.transform.position);
            if (unit.Team == this.Team)
            {
            }
            else
            {


                if (distance < closestDist)
                {
                    closestDist = distance;
                    Closestunit = unit;
                }
            }
        }
       
       
            return Closestunit;
        
     }
    public Building ClosestUnit(Building[] units)
    {
        float closestDist = int.MaxValue;
        float distance = 0;
        Building Closestunit = null;
        foreach (Building unit in units)
        {
            distance = Vector3.Distance(transform.position, unit.transform.position);
            if (unit.Team == this.Team)
            {
            }
            else
            {


                if (distance < closestDist)
                {
                    closestDist = distance;
                    Closestunit = unit;
                }
            }
        }
        
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
            Enemy.HP = Enemy.HP - this.attack;        
    }
    public void Combat(Building Enemy)
    {      
            Enemy.HP = Enemy.HP - this.attack;              
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

   



    void Update()
    {
        
        if (Death())
        {
            GameEngine gameEngine = GameObject.FindObjectOfType<GameEngine>();
            if (Team == "Team 1")
            {
                gameEngine.t2Resources += 50;
            }
            else
            {
                gameEngine.t1Resources += 50;
            }
            Destroy(gameObject);
        }
        else
        {
           


                Unit[] Units;
                Building[] buildings;
                Units = GameObject.FindObjectsOfType<Unit>();
                buildings = GameObject.FindObjectsOfType<Building>();
                Unit closestUnit = null;
                if (Units != null)
                {
                    closestUnit = ClosestUnit(Units);
                }
                Building closestbuilding = ClosestUnit(buildings);


                if (closestUnit == null || Vector3.Distance(transform.position, closestbuilding.transform.position) <= Vector3.Distance(transform.position, closestUnit.transform.position) && name != "Mage" && !closestbuilding.Death())
                {

                    bool attacking = this.InAttackRange(closestbuilding);
                    if (!attacking)
                    {
                        Movement(closestbuilding);
                    }
                    else
                    {
                        Combat(closestbuilding);
                    }
                }
                else
                {
                    if (closestUnit == this)
                    { }
                    else
                    {

                        bool attacking = this.InAttackRange(closestUnit);
                        if (!attacking)
                        {
                            Movement(closestUnit);
                        }
                        else
                        {
                            if (this.Name == "Mage")
                            {
                                WizardAOE(Units);
                            }
                            else
                            {
                                Combat(closestUnit);
                            }
                        }
                    }
                }
            
        }

        healthBar = GetComponentsInChildren<Image>()[1];
        healthBar.fillAmount = (float)HP / MaxHP;
    }

    public bool RunAway()
    {
        if (Name == "Mage")
        {
            if (HP/MaxHP <= 0.5)
            {
                return true;
            }
            else
            {
                return false;     
            }
        }
        else
        {
            if (HP / MaxHP <= 0.25)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void WizardAOE(Unit[] units)
    {
       
            for (int i = 0; i < units.Length; i++)
            {
                if (Vector3.Distance(units[i].transform.position,this.transform.position)<this.AttackRange)
                {
                    if (units[i].Name != "Mage")
                    {
                        Combat(units[i]);
                    }

                }
            }
        
    }

}
