using TMPro;
using UnityEngine;

public static class BattleHandler
{
    public static Entity attacker;
    public static Entity target;

    public static string battleDialogue;
    public static bool isButtonPressed;
    public static bool hasEscaped = false;
    public static bool triedToEscape;

    //Handles the current state of battle and the effects
    public static void SetState(Entity newAttacker, Entity newTarget)
    {
        attacker = newAttacker;
        target = newTarget;
        isButtonPressed = false;
        triedToEscape = false;
    }

    //basic attack effect

    public static int WeaponAttack()
    {
        float basePower = attacker.BasicAttack();
        float defense = target.PhyDefense();
        float damageCalculator = basePower - defense;
        int damage = Mathf.RoundToInt(damageCalculator);
        if (damage <= 0)
        {
            damage = 1;
        }

        target.TakeDamage(damage);

        DamagePopup.Create(target.transform.position, target.IsPlayerEntity, damage, false, false);
        return damage;
    }
    public static void ActivateSkill(string skill)
    {
        attacker.UseSkill(skill);
    }

    //basic skill effect
    public static void SkillAttack(int skillDamage, bool isPhysical)
    {
        float baseDamage = attacker.SkillAttack(isPhysical);
        float defense = target.SkillDefense(isPhysical);

        float damageCalculator = (baseDamage - defense) * (skillDamage / 100);

        int damage = Mathf.RoundToInt(damageCalculator);

        if (damage <= 0)
        {
            damage = 1;
        }

        DamagePopup.Create(target.transform.position, target.IsPlayerEntity, damage, false, false);

        target.TakeDamage(damage);
    }

    public static void SkillHeal(int healingPower)
    {
        float healCalculator = attacker.MagDefense() * (healingPower / 100);
        target.RestoreHealth(Mathf.RoundToInt(healCalculator));
    }
    public static void ItemHeal(int health)
    {
        target.RestoreHealth(health);
    }

    public static void TryToEscape(float random)
    {
        triedToEscape = true;

        if (random < 0.8f)
        {
            hasEscaped = true;
        }
    }

    public static bool TriedToEscape()
    {
        return triedToEscape;
    }

    public static bool HasEscaped()
    {
        if(hasEscaped)
        {
            battleDialogue = "You have escaped!";
            return hasEscaped;
        }
        battleDialogue = "You failed to escape.";
        return hasEscaped;
    }

    public static bool IsTargetDead()
    {
        return target.IsDead();
    }

    public static void SetDialogue(string dialogue)
    {
        battleDialogue = dialogue;
    }

    public static string GetDialogue()
    {
        return battleDialogue;
    }

    public static bool Hit()
    {
        double accuracy = (double)(attacker.Accuracy() - target.Evasion() / 100);
        return true;
    }

    public static bool IsButtonPressed()
    {
        return isButtonPressed;
    }

    public static void ButtonPressed()
    {
        isButtonPressed = true;
    }
}
