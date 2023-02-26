using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Entity
{
    public GameObject menuGO;
    public GameObject playerImage;

    public string entityName { get; set; }
    public int entityLevel { get; set; }
    public bool isPlayerEntity { get; set; }

    public int maxHealth { get; set; }
    public int currentHealth { get; set; }

    public int strength { get; set; }
    public int magic { get; set; }
    public int endurance { get; set; }
    public int agility { get; set; }

    public List<Skill> skills { get; set; }

    public bool isCurrentTurn { get; set; }
    public bool isDead { get; set; }

    public int maxMana;
    public int currentMana;

    public int levelUpExp;
    public int currentExp;

    private int healthScale;
    private int damageScale;
    private int magicScale;
    private int defenseScale;
    private int speedScale;
    private int manaScale;


    private Weapon currentWeapon;

    public Player()
    {
        entityName = "None";
        entityLevel = 1;

        isPlayerEntity = true;
        isCurrentTurn = false;
        isDead = false;

        healthScale = 10;
        damageScale = 5;
        magicScale = 3;
        defenseScale = 2;
        speedScale = 3;
        manaScale = 10;

        currentExp = 0;
        levelUpExp = 100;

        currentWeapon = new Weapon();

        skills = new List<Skill>
        {
            new Skill(),
            new Skill("Agi", 4, 80)
        };

        UpdateStats();

        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    public Player(string entityName, int entityLevel, int healthScale, int damageScale, int magicScale, int defenseScale, int speedScale, int manaScale)
    {
        this.entityName = entityName;
        this.entityLevel = entityLevel;

        isPlayerEntity = true;
        isCurrentTurn = false;
        isDead = false;

        this.healthScale = healthScale;
        this.damageScale = damageScale;
        this.magicScale = magicScale;
        this.defenseScale = defenseScale;
        this.speedScale = speedScale;
        this.manaScale = manaScale;

        currentExp = 0;
        levelUpExp = 100;

        skills = new List<Skill>
        {
            new Skill(),
            new Skill("Agi", 4, 80)
        };

        UpdateStats();

        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    public void SetPlayerStats(Player playerData)
    {
        entityName = playerData.entityName;
        entityLevel = playerData.entityLevel;

        currentHealth = playerData.currentHealth;
        currentMana = playerData.currentMana;

        healthScale = playerData.healthScale;
        damageScale = playerData.damageScale;
        magicScale = playerData.magicScale;
        defenseScale = playerData.defenseScale;
        speedScale = playerData.speedScale;
        manaScale = playerData.manaScale;

        currentExp = playerData.currentExp;
        levelUpExp = playerData.levelUpExp;

        skills = playerData.skills;

        UpdateStats();
    }

    public void SetPlayerStats(string entityName, int entityLevel, int currentHealth, int currentMana, int healthScale, int damageScale, int magicScale, int defenseScale, int speedScale, int manaScale)
    {
        this.entityName = entityName;
        this.entityLevel = entityLevel;

        this.currentHealth = currentHealth;
        this.currentMana = currentMana;

        this.healthScale = healthScale;
        this.damageScale = damageScale;
        this.magicScale = magicScale;
        this.defenseScale = defenseScale;
        this.speedScale = speedScale;
        this.manaScale= manaScale;

        currentExp = 0;
        levelUpExp = 100;

        UpdateStats();
    }

    public void OutOfCombat()
    {
        menuGO.GetComponent<MenuUI>().DisableSkillList();
        menuGO.SetActive(false);
        playerImage.SetActive(false);
    }

    public void InCombat()
    {
        playerImage.SetActive(true);
    }

    public void IsCurrentTurn()
    {
        isCurrentTurn = true;
        menuGO.SetActive(true);
    }

    public void TurnEnded()
    {
        isCurrentTurn = false;
        menuGO.GetComponent<MenuUI>().DisableSkillList();
        menuGO.SetActive(false);
    }

    public bool Hit()
    {
        float random = Random.value;
        if (random < currentWeapon.weaponAccuracy)
        {
            return true;
        }
        return false;
    }

    public float WeaponDamage()
    {
        return Mathf.Sqrt(0.5f * currentWeapon.weaponDamage) * Mathf.Sqrt(strength);
    }

    public void LevelUp()
    {
        entityLevel++;
        UpdateStats();
    }

    private void UpdateStats()
    {
        maxHealth = healthScale * entityLevel;

        strength = damageScale * entityLevel;
        endurance = defenseScale * entityLevel;
        magic = magicScale * entityLevel;
        agility = speedScale * entityLevel;

        maxMana = manaScale * entityLevel;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Died();
        }
    }

    public bool CanUseSkill(string skillName)
    {
        var index = skills.FindIndex(f => f.skillName == skillName);

        if (index != -1)
        {
            if (currentMana >= skills[index].skillCost)
            {
                return true;
            }
        }
        else
        {
            Debug.Log("Cannot find Skill");
        }
        return false;
    }

    public Skill UseSkill(string skillName)
    {
        var index = skills.FindIndex(f => f.skillName == skillName);

        currentMana -= skills[index].skillCost;
        return skills[index];
    }

    public bool Heal(int healing)
    {
        if(currentHealth < maxHealth)
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

    public void GainExp(int exp)
    {
        currentExp += exp;
        if(currentExp >= levelUpExp)
        {
            currentExp -= levelUpExp;
            LevelUp();
        }
    }

    public void Died()
    {
        isDead = true;
    }

    public void UpdateHUD() { }
}
