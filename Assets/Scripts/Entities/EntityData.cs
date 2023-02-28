using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Data all entities will have that can be saved seperate from the entities themselves
public class EntityData
{
    //Basic Entity Data
    public string EntityName { get; set; }
    public int EntityLevel { get; set; }
    public bool IsPlayerEntity { get; set; }

    //Health Data
    public int MaxHealthPoints { get; set; }
    public int CurrentHealthPoints { get; set; }

    //Mana/Magic Data
    public int MaxSpellPoints { get; set; }
    public int CurrentSpellPoints { get; set; }

    //Entity base stats
    public int PhyAttack { get; set; }
    public int MagAttack { get; set; }
    public int PhyDefense { get; set; }
    public int MagDefense { get; set; }
    public int Accuracy { get; set; }
    public int Speed { get; set; }
    public int Critical { get; set; }
    public int Evasion { get; set; }

    //Entity battle parameters
    public bool IsCurrentTurn { get; set; }

    public List<Skill> Skills;

    //If entity is dead or not
    public bool IsDead { get; set; }

    //Default Constructor
    public EntityData()
    {
        EntityName = "None";
        EntityLevel = 1;
        IsPlayerEntity = false;


        IsCurrentTurn = false;
        IsDead = false;


    }
}
