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
    public static void Attack()
    {
        float basePower = attacker.WeaponDamage();
        float damageCalculator = basePower / Mathf.Sqrt(target.endurance * 8);
        target.TakeDamage(Mathf.RoundToInt(damageCalculator));
        float damage = Player.Instance.WeaponDamage();
    }

    //basic skill effect
    public static void SkillAttack(string skill)
    {
        Skill attack = attacker.UseSkill(skill);
        if(attack != null)
        {
            float basePower = Mathf.Sqrt(attack.skillDamage) * Mathf.Sqrt(attacker.magic);
            float damageCalculator = basePower / Mathf.Sqrt(target.endurance * 8);

            target.TakeDamage(Mathf.RoundToInt(damageCalculator));
        }
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
        return target.isDead;
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
        return attacker.Hit();
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
