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

    public int healAmount;

    public HealthPotion() 
    {
        healAmount = 10;
    }

    public HealthPotion(int healAmount)
    {
        this.healAmount = healAmount;
    }

    public void ItemEffect()
    {
        BattleHandler.Heal(healAmount);
    }
}

public class ManaPotion : IConsumable
{
    public string ItemName { get; set; }
    public int ItemCost { get; set; }

    public int restoreAmount;

    public ManaPotion()
    {
        restoreAmount = 10;
    }

    public ManaPotion(int restoreAmount)
    {
        this.restoreAmount = restoreAmount;
    }

    public void ItemEffect()
    {
        BattleHandler.Heal(restoreAmount);
    }
}