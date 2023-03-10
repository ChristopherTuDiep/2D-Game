using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public string ItemName { get; set; }
    public int ItemCost { get; set; }
    public int ItemAmount { get; set; }
    public bool IsUsable { get; set; }
    public int InUse { get; set; }

    public int phyDefense;
    public int magDefense;

    public Armor()
    {
        ItemName = "Basic Armor";
        ItemCost = 0;
        ItemAmount = 1;
        IsUsable = false;
        InUse = 0;

        phyDefense = 0;
        magDefense = 0;
    }

    public Armor(string armorName, int armorCost, int itemAmount, int phyDefense, int magDefense)
    {
        ItemName = armorName;
        ItemCost = armorCost;
        ItemAmount = itemAmount;
        IsUsable = false;
        InUse = 0;

        this.phyDefense = phyDefense;
        this.magDefense = magDefense;
    }
}
