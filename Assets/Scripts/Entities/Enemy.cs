using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public GameObject currentGameObject;
    public EnemyHUD enemyHUD;

    public float accuracy;
    public int exp;

    public Enemy() : base() 
    {
        IsPlayerEntity = false;

        accuracy = 0.8f;
        exp = 50;
    }

    public Enemy(string entityName, int entityLevel, int healthScale, int damageScale, int magicScale, int defenseScale, int speedScale, float accuracy)
    {
        EntityName = entityName;
        EntityLevel = entityLevel;

        IsPlayerEntity = false;
        IsCurrentTurn = false;
        IsDead = false;

        HealthScale = healthScale;
        DamageScale = damageScale;
        MagicScale = magicScale;
        DefenseScale = defenseScale;
        SpeedScale = speedScale;

        Skills = new List<Skill>
        {
            new Skill()
        };

        UpdateStats();
    }

    public override bool Hit()
    {
        float random = Random.value;
        if(random < accuracy)
        {
            return true;
        }
        return false;
    }

    public int ExpWorth()
    {
        return exp;
    }

    public override void Died()
    {
        IsDead = true;
        currentGameObject.SetActive(false);
    }

    public override void UpdateHUD()
    {
        enemyHUD.SetHealth(CurrentHealth);
    }
}
