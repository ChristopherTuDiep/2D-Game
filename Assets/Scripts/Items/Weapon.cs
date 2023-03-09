using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public string ItemName { get; set; }
    public int ItemCost { get; set; }
    public int ItemAmount { get; set; }
    public bool IsUsable { get; set; }
    public int InUse { get; set; }

    public int physicalAtk;
    public int magicAtk;

    public Weapon()
    {
        ItemName = "Basic Weapon";
        ItemCost = 0;
        ItemAmount = 1;
        IsUsable = false;
        InUse = 0;

        physicalAtk = 0;
        magicAtk = 0;
    }

    public Weapon(string weaponName, int weaponCost, int itemAmount, int weaponPhysicalDamage, int weaponMagicDamage, float weaponAccuracy)
    {
        ItemName = weaponName;
        ItemCost = weaponCost;
        ItemAmount = itemAmount;
        IsUsable = false;
        InUse = 0;

        physicalAtk = weaponPhysicalDamage;
        magicAtk = weaponMagicDamage;
    }
}
