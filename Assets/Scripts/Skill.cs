using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public string skillName;
    public int skillCost;
    public int skillDamage;

    public Skill()
    {
        skillName = "Basic Skill";
        skillCost = 5;
        skillDamage = 40;
    }

    public Skill(string skillName, int skillCost, int skillDamage)
    {
        this.skillName = skillName;
        this.skillCost = skillCost;
        this.skillDamage = skillDamage;
    }

    public void ActivateSpell()
    {
        
    }
}
