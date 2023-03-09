using System.Collections.Generic;
using UnityEngine;

//Data all entities will have that can be saved seperate from the entities themselves
public class EntityData
{
    //Entity Sprite
    private Sprite sprite;
    //Basic Entity Data
    public string EntityName { get; set; }
    public int EntityLevel { get; set; }

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
    public Weapon currentWeapon { get; set; }
    public Armor currentArmor { get; set; }

    //Entity battle parameters
    public List<Skill> Skills;

    //If entity is dead or not
    public bool IsDead { get; set; }

    //For the player, their current exp, for the enemies, the exp they will give
    public int Exp { get; set; }

    //Default Constructor
    public EntityData()
    {

        EntityName = "None";
        EntityLevel = 1;

        MaxHealthPoints = 10;
        CurrentHealthPoints = MaxHealthPoints;

        MaxSpellPoints = 10;
        CurrentSpellPoints = MaxSpellPoints;

        PhyAttack = 5;
        MagAttack = 5;
        PhyDefense = 5;
        MagDefense = 5;
        Accuracy = 5;
        Speed = 5;
        Critical = 5;
        Evasion = 5;

        Skills = new List<Skill>
        {
            new Skill(),
            new Skill("Agi", 4, 80, false)
        };

        currentWeapon = new Weapon();
        currentArmor = new Armor();

        IsDead = false;

        Exp = 0;
    }

    public EntityData(string entityName, int entityLevel, bool isPlayerEntity, int maxHealthPoints, int maxSpellPoints, int phyAttack, int magAttack, int phyDefense, int magDefense, int accuracy, int speed, int critical, int evasion, List<Skill> skills, int exp)
    {
        EntityName = entityName;
        EntityLevel = entityLevel;

        MaxHealthPoints = maxHealthPoints;
        CurrentHealthPoints = MaxHealthPoints;

        MaxSpellPoints = maxSpellPoints;
        CurrentSpellPoints = MaxSpellPoints;

        PhyAttack = phyAttack;
        MagAttack = magAttack;
        PhyDefense = phyDefense;
        MagDefense = magDefense;
        Accuracy = accuracy;
        Speed = speed;
        Critical = critical;
        Evasion = evasion;

        Skills = skills;

        currentWeapon = new Weapon();
        currentArmor = new Armor();

        IsDead = false;

        Exp = exp;
    }

    public EntityData(string entityName, int entityLevel, bool isPlayerEntity, int maxHealthPoints, int maxSpellPoints, int phyAttack, int magAttack, int phyDefense, int magDefense, int accuracy, int speed, int critical, int evasion, Weapon weapon, Armor armor, List<Skill> skills, int exp)
    {
        EntityName = entityName;
        EntityLevel = entityLevel;

        MaxHealthPoints = maxHealthPoints;
        CurrentHealthPoints = MaxHealthPoints;

        MaxSpellPoints = maxSpellPoints;
        CurrentSpellPoints = MaxSpellPoints;

        PhyAttack = phyAttack;
        MagAttack = magAttack;
        PhyDefense = phyDefense;
        MagDefense = magDefense;
        Accuracy = accuracy;
        Speed = speed;
        Critical = critical;
        Evasion = evasion;

        Skills = skills;

        currentWeapon = weapon;
        currentArmor = armor;

        IsDead = false;

        Exp = exp;
    }

    public void CopyData(EntityData entityData)
    {
        EntityName = entityData.EntityName;
        EntityLevel = entityData.EntityLevel;

        MaxHealthPoints = entityData.MaxHealthPoints;
        CurrentHealthPoints = entityData.CurrentHealthPoints;

        MaxSpellPoints = entityData.MaxSpellPoints;
        CurrentSpellPoints = entityData.CurrentSpellPoints;

        PhyAttack = entityData.PhyAttack;
        MagAttack = entityData.MagAttack;
        PhyDefense = entityData.PhyDefense;
        MagDefense = entityData.MagDefense;
        Accuracy = entityData.Accuracy;
        Speed = entityData.Speed;
        Critical = entityData.Critical;
        Evasion = entityData.Evasion;

        Skills = entityData.Skills;

        IsDead = entityData.IsDead;

        Exp = entityData.Exp;
    }

    public void CopyData(string entityName, int entityLevel, bool isPlayerEntity, int maxHealthPoints, int currentHealthPoints, int maxSpellPoints, int currentSpellPoints, int phyAttack, int magAttack, int phyDefense, int magDefense, int accuracy, int speed, int critical, int evasion, List<Skill> skills, bool isDead, int exp)
    {
        EntityName = entityName;
        EntityLevel = entityLevel;

        MaxHealthPoints = maxHealthPoints;
        CurrentHealthPoints = currentHealthPoints;

        MaxSpellPoints = maxSpellPoints;
        CurrentSpellPoints = currentSpellPoints;

        PhyAttack = phyAttack;
        MagAttack = magAttack;
        PhyDefense = phyDefense;
        MagDefense = magDefense;
        Accuracy = accuracy;
        Speed = speed;
        Critical = critical;
        Evasion = evasion;

        Skills = skills;

        IsDead = isDead;

        Exp = exp;
    }

    //Some system to fully restore health and spellpoints
    public void FullRestore()
    {
        CurrentHealthPoints = MaxHealthPoints;
        CurrentSpellPoints = MaxSpellPoints;
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        newWeapon.InUse++;
        currentWeapon.InUse--;
        currentWeapon = newWeapon;
    }
    public void EquipArmor(Armor newArmor)
    {
        newArmor.InUse++;
        currentArmor.InUse--;
        currentArmor = newArmor;
    }
}
