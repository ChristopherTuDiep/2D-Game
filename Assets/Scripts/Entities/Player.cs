using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public GameObject menuGO;
    public GameObject skillListGO;
    public GameObject playerImage;

    private CharacterHUD characterHUD;

    public int levelUpExp;

    private Weapon currentWeapon;
    private Armor currentArmor;

    public Player() : base()
    {
        IsPlayerEntity = true;

        levelUpExp = 100;

        currentWeapon = new Weapon();
        currentArmor = new Armor();
    }

    public Player(string entityName, int entityLevel, int maxHealthPoints, int maxSpellPoints, int phyAttack, int magAttack, int phyDefense, int magDefense, int accuracy, int speed, int critical, int evasion, List<Skill> skills, int exp, int levelUpExp)
        : base(entityName, entityLevel, true, maxHealthPoints, maxSpellPoints, phyAttack, magAttack, phyDefense, magDefense, accuracy, speed, critical, evasion, skills, exp)
    {
        IsPlayerEntity = true;

        this.levelUpExp = levelUpExp;

        currentWeapon = new Weapon();
        currentArmor = new Armor();
    }

    public Player(EntityData data, int levelUpExp)
    {
        IsPlayerEntity = true;

        this.data = data;
        this.levelUpExp = levelUpExp;

        currentWeapon = new Weapon();
        currentArmor = new Armor();
    }

    public EntityData GetPlayerData()
    {
        return data;
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

    public bool GainExp(int exp)
    {
        data.Exp += exp;
        if(data.Exp >= levelUpExp)
        {
            data.Exp -= levelUpExp;
            return true;
        }
        return false;
    }

    public void LevelUp()
    {
        data.EntityLevel++;
    }

    public override void Died()
    {
        data.CurrentHealthPoints = 0;
        data.IsDead = true;
    }

    public void SetHUD(CharacterHUD hud)
    {
        characterHUD = hud;
    }

    public override void UpdateHUD() 
    {
        characterHUD.SetName(data.EntityName);

        characterHUD.SetMaxHealth(data.MaxHealthPoints);
        characterHUD.SetHealth(data.CurrentHealthPoints);
        characterHUD.SetMaxMana(data.MaxSpellPoints);
        characterHUD.SetMana(data.CurrentSpellPoints);
        characterHUD.SetMaxExp(levelUpExp);
        characterHUD.SetExp(data.Exp);
    }

    private void Update()
    {
        menuGO.SetActive(IsCurrentTurn);
        if(!IsCurrentTurn)
        {
            menuGO.GetComponent<MenuUI>().DisableSkillList();
        }
    }
}
