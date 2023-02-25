using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Entity
{
    public string entityName { get; set; }
    public int entityLevel { get; set; }
    public bool isPlayerEntity { get; set; }

    public int maxHealth { get; set; }
    public int currentHealth { get; set; }

    public int strength { get; set; }
    public int magic { get; set; }
    public int endurance { get; set; }
    public int agility { get; set; }

    public bool isCurrentTurn { get; set; }

    public GameObject hudPrefab;
    public EnemyHUD enemyHUD;
    public List<Skill> skills { get; set; }

    public bool isDead { get; set; }

    public int exp;

    private int healthScale;
    private int damageScale;
    private int magicScale;
    private int defenseScale;
    private int speedScale;
    private float accuracy;

    public GameObject currentGameObject;

    public Enemy()
    {
        entityName = "None";
        entityLevel = 1;

        isPlayerEntity = false;
        isCurrentTurn = false;
        isDead = false;

        healthScale = 10;
        damageScale = 5;
        magicScale = 3;
        defenseScale = 2;
        speedScale = 2;
        accuracy = 0.5f;

        exp = 100;

        skills = new List<Skill>
        {
            new Skill()
        };

        UpdateStats();
    }

    public Enemy(string entityName, int entityLevel, int healthScale, int damageScale, int magicScale, int defenseScale, int speedScale, float accuracy)
    {
        this.entityName = entityName;
        this.entityLevel = entityLevel;

        isPlayerEntity = false;
        isCurrentTurn = false;
        isDead = false;

        this.healthScale = healthScale;
        this.damageScale = damageScale;
        this.magicScale = magicScale;
        this.defenseScale = defenseScale;
        this.speedScale = speedScale;
        this.accuracy = accuracy;

        exp = 100;

        skills = new List<Skill>
        {
            new Skill()
        };

        UpdateStats();
    }
    public void IsCurrentTurn()
    {
        isCurrentTurn = true;
    }

    public void TurnEnded()
    {
        isCurrentTurn = false;
    }

    public void UpdateHUD()
    {
        enemyHUD.SetHealth(currentHealth);
    }

    public void UpdateStats()
    {
        maxHealth = healthScale * entityLevel;
        currentHealth = maxHealth;

        strength = damageScale * entityLevel;
        endurance = defenseScale * entityLevel;
        magic = magicScale * entityLevel;
        agility = speedScale * entityLevel;
    }
    public bool Hit()
    {
        float random = Random.value;
        if(random < accuracy)
        {
            return true;
        }
        return false;
    }

    public float WeaponDamage()
    {
        return Mathf.Sqrt(0.5f * 30) * Mathf.Sqrt(strength);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Died();
        }
    }

    public Skill UseSkill(string skillName)
    {
        var index = skills.FindIndex(f => f.skillName == skillName);
        if (index != -1)
        {
            return skills[index];
        }
        else
        {
            Debug.Log("Cannot find Spell");
        }
        return null;
    }

    public bool Heal(int healing)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healing;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            return true;
        }
        return false;
    }

    public int ExpWorth()
    {
        return exp;
    }

    public void Died()
    {
        isDead = true;
        currentGameObject.SetActive(false);
    }
}
