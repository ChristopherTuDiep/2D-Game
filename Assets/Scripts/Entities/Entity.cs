using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public enum Multiplier
{
    Default,
    Debuff,
    Buff
}

public abstract class Entity : MonoBehaviour
{
    public bool IsPlayerEntity { get; set; }

    [SerializeField] EntityAnimatorController animationController;

    protected EntityData data;

    /*
    Physical Attack = 0
    Physical Defense = 1
    Magic Attack = 2
    Magic Defense = 3
    Accuracy = 4
    Speed = 5
    Critical = 6
    Evasion = 7
*/
    protected int[] multipliers;

    private readonly int _NUMBER_OF_MULTIPLIERS = 8;
    private readonly float _DEFAULT_MULTIPLIER = 1.0f;
    private readonly float _BUFF_MULTIPLIER = 1.5f;
    private readonly float _DEBUFF_MULTIPLIER = 0.66f;
    public bool IsCurrentTurn { get; set; }

    [SerializeField] private AudioSource weaponEffect;

    public Entity()
    {
        IsPlayerEntity = false;
        data = new EntityData();
        multipliers = new int[_NUMBER_OF_MULTIPLIERS];
    }

    public Entity(bool playerEntity, EntityData data)
    {
        IsPlayerEntity = playerEntity;
        this.data = data;
        multipliers = new int[_NUMBER_OF_MULTIPLIERS];
    }

    public Entity(string entityName, int entityLevel, bool isPlayerEntity, int maxHealthPoints, int maxSpellPoints, int phyAttack, int magAttack, int phyDefense, int magDefense, int accuracy, int speed, int critical, int evasion, List<Skill> skills, int exp)
    {
        data = new EntityData(entityName, entityLevel, isPlayerEntity, maxHealthPoints, maxSpellPoints, phyAttack, magAttack, phyDefense, magDefense, accuracy, speed, critical, evasion, skills, exp);
        multipliers = new int[_NUMBER_OF_MULTIPLIERS];
    }

    public void SetData(EntityData data)
    {
        this.data = data;
    }

    //Modifier stuff
    public int MultiplierLocation(string multiplierName)
    {
        switch (multiplierName)
        {
            case "phyAttack":
                return 0;
            case "phyDefense":
                return 1;
            case "magAttack":
                return 2;
            case "magDefense":
                return 3;
            case "accuracy":
                return 4;
            case "speed":
                return 5;
            case "critical":
                return 6;
            case "evasion":
                return 7;
            default:
                return -1;
        }
    }

    private float GetMultiplier(int location)
    {
        int current = multipliers[location];
        switch (current)
        {
            case -1:
                return _DEBUFF_MULTIPLIER;
            case 0:
                return _DEFAULT_MULTIPLIER;
            case 1:
                return _BUFF_MULTIPLIER;
            default:
                return -1.0f;
        }
    }
    public int MaxHealth()
    {
        return data.MaxHealthPoints;
    }
    public int CurrentHealth()
    {
        return data.CurrentHealthPoints;
    }
    public void SetMultiplier(Multiplier multiplier, int location)
    {
        switch (multiplier)
        {
            case Multiplier.Default:
                multipliers[location] = 0;
                break;
            case Multiplier.Debuff:
                multipliers[location] = -1;
                break;
            case Multiplier.Buff:
                multipliers[location] = 1;
                break;
            default:
                break;
        }
    }
    //Getting entity attributes
    public float PhyAttack()
    {
        return GetMultiplier(0) * (data.PhyAttack + data.currentWeapon.physicalAtk);
    }

    public float PhyDefense()
    {
        return GetMultiplier(1) * (data.PhyDefense + data.currentArmor.phyDefense);
    }

    public float MagAttack()
    {
        return GetMultiplier(2) * (data.MagAttack + data.currentWeapon.magicAtk);
    }

    public float MagDefense()
    {
        return GetMultiplier(3) * (data.MagDefense + data.currentArmor.magDefense);
    }

    public float Accuracy()
    {
        return GetMultiplier(4) * data.Accuracy;
    }

    public float Speed()
    {
        return GetMultiplier(5) * data.Speed;
    }

    public float Critical()
    {
        return GetMultiplier(6) * data.Critical;
    }

    public float Evasion()
    {
        return GetMultiplier(7) * data.Evasion;
    }

    public List<Skill> GetSkills()
    {
        return data.Skills;
    }

    //How you take damage
    public void TakeDamage(int damage)
    {
        data.CurrentHealthPoints -= damage;

        if (data.CurrentHealthPoints <= 0)
        {
            Died();
        }
    }

    //Checks that the current entity can use the skill specified
    public bool CanUseSkill(string skillName)
    {
        var index = data.Skills.FindIndex(f => f.skillName == skillName);
        if(index != -1 && !data.Skills[index].isPhysical && data.Skills[index].skillCost <= data.CurrentSpellPoints)
        {
            return true;
        }
        else if (index != -1 && data.Skills[index].isPhysical)
        {
            int physicalCost = Mathf.RoundToInt(((float)data.Skills[index].skillCost / 100.0f) * data.MaxHealthPoints);
            if(physicalCost < data.CurrentHealthPoints)
            {
                return true;
            }
        }
        return false;
    }

    public float BasicAttack()
    {
        animationController.BasicWeaponAttack();
        weaponEffect.Play();
        return PhyAttack();
    }
    //Gets data needed for the battle instance
    public float SkillAttack(bool isPhysical)
    {
        if(isPhysical)
        {
            animationController.PhysicalSkillAttack();
            weaponEffect.Play();
            return PhyAttack();
        }
        else
        {
            return MagAttack();
        }
    }

    public float SkillDefense(bool isPhysical)
    {
        if(isPhysical)
        {
            return PhyDefense();
        }
        else
        {
            return MagDefense();
        }
    }

    public void SkillHeal(string skillName)
    {
        UseSkill(skillName);
    }

    //Uses skill and subtracts SP/Health
    public void UseSkill(string skillName)
    {
        var index = data.Skills.FindIndex(f => f.skillName == skillName);
        if (index != -1 && !data.Skills[index].isPhysical)
        {
            data.CurrentSpellPoints -= data.Skills[index].skillCost;
            data.Skills[index].ActivateSkill();
        }
        else if(index != 1 && data.Skills[index].isPhysical)
        {
            data.CurrentHealthPoints -= Mathf.RoundToInt(((float)data.Skills[index].skillCost / 100.0f) * data.MaxHealthPoints);
            data.Skills[index].ActivateSkill();
        }
        else
        {
            Debug.Log("Cannot find Spell");
        }
    }

    //Makes sure nothing tried to restore your bars if they don't need to
    public bool NeedHealing()
    {
        if(data.CurrentHealthPoints < data.MaxHealthPoints)
        {
            return true;
        }
        return false;
    }

    public void RestoreHealth(int healing)
    {
        data.CurrentHealthPoints += healing;
        if (data.CurrentHealthPoints > data.MaxHealthPoints)
        {
            data.CurrentHealthPoints = data.MaxHealthPoints;
        }
    }

    public bool NeedSpellPoints()
    {
        if(data.CurrentSpellPoints < data.MaxSpellPoints)
        {
            return true;
        }
        return false;
    }

    public void RestoreSpellPoints(int spellPoints)
    {
        data.CurrentSpellPoints += spellPoints;
        if(data.CurrentSpellPoints < data.MaxSpellPoints)
        {
            data.CurrentSpellPoints = data.MaxSpellPoints;
        }
    }

    public bool IsDead()
    {
        return data.IsDead;
    }

    //Abstract classes other classes need to define
    public abstract void Died();

    public abstract void UpdateHUD();
}
