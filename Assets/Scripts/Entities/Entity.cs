using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public string EntityName { get; set; }
    protected int EntityLevel { get; set; }
    public bool IsPlayerEntity { get; set; }

    public int MaxHealth;
    public int CurrentHealth;

    public int MaxMana;
    public int CurrentMana;

    protected int Strength;
    protected int Magic;
    protected int Endurance;
    protected int Agility;

    protected int HealthScale;
    protected int DamageScale;
    protected int MagicScale;
    protected int DefenseScale;
    protected int SpeedScale;
    protected int ManaScale;

    public bool IsCurrentTurn { get; set; }

    protected List<Skill> Skills;
    public bool IsDead { get; set; }

    public Entity()
    {
        EntityName = "None";
        EntityLevel = 1;

        IsCurrentTurn = false;
        IsDead = false;

        HealthScale = 10;
        DamageScale = 5;
        MagicScale = 3;
        DefenseScale = 2;
        SpeedScale = 2;
        Skills = new List<Skill>
        {
            new Skill()
        };

        UpdateStats();

        FullRestore();
    }

    public void FullRestore()
    {
        CurrentHealth = MaxHealth; 
        CurrentMana = MaxMana;
    }

    public void UpdateStats()
    {
        MaxHealth = HealthScale * EntityLevel;

        MaxMana = ManaScale * EntityLevel;

        Strength = DamageScale * EntityLevel;
        Endurance = DefenseScale * EntityLevel;
        Magic = MagicScale * EntityLevel;
        Agility = SpeedScale * EntityLevel;
    }

    public int GetStrength()
    {
        return Strength;
    }

    public int GetMagic() 
    { 
        return Magic; 
    }

    public int GetEndurance()
    {
        return Endurance;
    }

    public int GetAgility()
    {
        return Agility;
    }

    public List<Skill> GetSkills()
    {
        return Skills;
    }

    public float WeaponDamage()
    {
        return Mathf.Sqrt(0.5f * 30) * Mathf.Sqrt(Strength);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Died();
        }
    }

    public bool CanUseSkill(string skillName)
    {
        var index = Skills.FindIndex(f => f.skillName == skillName);
        if(index != -1 && Skills[index].skillCost <= CurrentMana)
        {
            return true;
        }
        return false;
    }

    public Skill UseSkill(string skillName)
    {
        var index = Skills.FindIndex(f => f.skillName == skillName);
        if (index != -1)
        {
            CurrentMana -= Skills[index].skillCost;
            return Skills[index];
        }
        else
        {
            Debug.Log("Cannot find Spell");
        }
        return null;
    }

    public bool NeedHealing()
    {
        if(CurrentHealth < MaxHealth)
        {
            return true;
        }
        return false;
    }

    public void RestoreHealth(int healing)
    {
        CurrentHealth += healing;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    public bool NeedMana()
    {
        if(CurrentMana < MaxMana)
        {
            return true;
        }
        return false;
    }

    public void RestoreMana(int mana)
    {
        CurrentMana += mana;
        if(CurrentMana < MaxMana)
        {
            CurrentMana = MaxMana;
        }
    }

    public abstract bool Hit();

    public abstract void Died();

    public abstract void UpdateHUD();
}
