using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConsumable : Item
{
    public void ItemEffect();
}

public class HealthPotion : IConsumable
{
    public string ItemName { get; set; }
    public int ItemCost { get; set; }
    public int ItemAmount { get; set; }
    public bool IsUsable { get; set; }

    public int healAmount;

    public HealthPotion() 
    {
        ItemName = "Health Potion";
        ItemCost = 10;
        ItemAmount = 1;
        IsUsable = false;
        healAmount = 10;
    }

    public HealthPotion(int healAmount)
    {
        this.healAmount = healAmount;
    }

    public void ItemEffect()
    {
        BattleHandler.ItemHeal(healAmount);
    }
}

public class ManaPotion : IConsumable
{
    public string ItemName { get; set; }
    public int ItemCost { get; set; }
    public int ItemAmount { get; set; }
    public bool IsUsable { get; set; }

    public int restoreAmount;

    public ManaPotion()
    {
        ItemName = "Mana Potion";
        ItemCost = 10;
        ItemAmount = 1;
        IsUsable = false;

        restoreAmount = 10;
    }

    public ManaPotion(int restoreAmount)
    {
        this.restoreAmount = restoreAmount;
    }

    public void ItemEffect()
    {
        BattleHandler.ItemHeal(restoreAmount);
    }
}