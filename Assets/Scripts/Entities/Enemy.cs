using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public GameObject currentGameObject;
    public EnemyHUD enemyHUD;


    public Enemy() : base() 
    {
        IsPlayerEntity = false;
    }

    public Enemy(string entityName, int entityLevel, int maxHealthPoints, int maxSpellPoints, int phyAttack, int magAttack, int phyDefense, int magDefense, int accuracy, int speed, int critical, int evasion, List<Skill> skills, int exp)
        : base(entityName, entityLevel, true, maxHealthPoints, maxSpellPoints, phyAttack, magAttack, phyDefense, magDefense, accuracy, speed, critical, evasion, skills, exp)
    {
        IsPlayerEntity = false;
    }

    public int ExpWorth()
    {
        return data.Exp;
    }

    public override void Died()
    {
        data.CurrentHealthPoints = 0;
        data.IsDead = true;
        currentGameObject.SetActive(false);
    }

    public override void UpdateHUD()
    {
        enemyHUD.SetHealth(data.CurrentHealthPoints);
    }
}
