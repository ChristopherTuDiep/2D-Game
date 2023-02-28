using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor
{
    public string ItemName { get; set; }
    public int ItemCost { get; set; }

    public int defense;

    public Armor()
    {
        ItemName = "Basic Armor";
        ItemCost = 0;

        defense = 10;
    }

    public Armor(string armorName, int armorCost, int defense)
    {
        ItemName = armorName;
        ItemCost = armorCost;

        this.defense = defense;
    }
}
