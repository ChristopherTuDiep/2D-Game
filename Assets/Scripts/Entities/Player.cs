using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public GameObject menuGO;
    public GameObject skillListGO;
    public GameObject playerImage;

    public int currentExp;
    public int levelUpExp;

    private Weapon currentWeapon;
    private Armor currentArmor;

    public Player() : base()
    {
        IsPlayerEntity = true;
        currentWeapon = new Weapon();
        currentArmor = new Armor();
    }

    public Player(string entityName, int entityLevel, int healthScale, int damageScale, int magicScale, int defenseScale, int speedScale, int manaScale)
    {
        EntityName = entityName;
        EntityLevel = entityLevel;

        IsPlayerEntity = true;
        IsCurrentTurn = false;
        IsDead = false;

        HealthScale = healthScale;
        DamageScale = damageScale;
        MagicScale = magicScale;
        DefenseScale = defenseScale;
        SpeedScale = speedScale;
        ManaScale = manaScale;

        currentExp = 0;
        levelUpExp = 100;

        Skills = new List<Skill>
        {
            new Skill(),
            new Skill("Agi", 4, 80)
        };

        currentWeapon = new Weapon();
        currentArmor = new Armor();

        UpdateStats();

        FullRestore();
    }

    public void SetPlayerStats(Player playerData)
    {
        EntityName = playerData.EntityName;
        EntityLevel = playerData.EntityLevel;

        CurrentHealth = playerData.CurrentHealth;
        CurrentMana = playerData.CurrentMana;

        HealthScale = playerData.HealthScale;
        DamageScale = playerData.DamageScale;
        MagicScale = playerData.MagicScale;
        DefenseScale = playerData.DefenseScale;
        SpeedScale = playerData.SpeedScale;
        ManaScale = playerData.ManaScale;

        currentExp = playerData.currentExp;
        levelUpExp = playerData.levelUpExp;

        Skills = playerData.Skills;

        UpdateStats();
    }

    public void SetPlayerStats(string entityName, int entityLevel, int currentHealth, int currentMana, int healthScale, int damageScale, int magicScale, int defenseScale, int speedScale, int manaScale)
    {
        EntityName = entityName;
        EntityLevel = entityLevel;

        CurrentHealth = currentHealth;
        CurrentMana = currentMana;

        HealthScale = healthScale;
        DamageScale = damageScale;
        MagicScale = magicScale;
        DefenseScale = defenseScale;
        SpeedScale = speedScale;
        ManaScale= manaScale;

        currentExp = 0;
        levelUpExp = 100;

        UpdateStats();
    }

    public Weapon EquipWeapon(Weapon newWeapon)
    {
        Weapon oldWeapon = currentWeapon;
        currentWeapon = newWeapon;
        return oldWeapon;
    }

    public Armor EquipArmor(Armor newArmor)
    {
        Armor oldArmor = currentArmor;
        currentArmor = newArmor;
        return oldArmor;
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

    public override bool Hit()
    {
        float random = Random.value;
        if (random < currentWeapon.weaponAccuracy)
        {
            return true;
        }
        return false;
    }

    public float PhysicalSkill()
    {
        return Mathf.Sqrt(currentWeapon.weaponPhysicalDamage) * Mathf.Sqrt(Strength);
    }

    public float MagicSkill()
    {
        return Mathf.Sqrt(currentWeapon.weaponMagicDamage) * Mathf.Sqrt(Strength);
    }

    public bool GainExp(int exp)
    {
        currentExp += exp;
        if(currentExp >= levelUpExp)
        {
            currentExp -= levelUpExp;
            return true;
        }
        return false;
    }

    public void LevelUp()
    {
        EntityLevel++;
        UpdateStats();
    }

    public override void Died()
    {
        IsDead = true;
    }

    public override void UpdateHUD() { }

    private void Update()
    {
        menuGO.SetActive(IsCurrentTurn);
        if(!IsCurrentTurn)
        {
            menuGO.GetComponent<MenuUI>().DisableSkillList();
        }
    }
}
