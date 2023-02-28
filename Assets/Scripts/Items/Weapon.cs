using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public string ItemName { get; set; }
    public int ItemCost { get; set; }

    public int weaponPhysicalDamage;
    public int weaponMagicDamage;
    public float weaponAccuracy;

    public Weapon()
    {
        ItemName = "Basic Weapon";
        ItemCost = 0;

        weaponPhysicalDamage = 38;
        weaponMagicDamage = 0;
        weaponAccuracy = 0.9f;
    }

    public Weapon(string weaponName, int weaponCost, int weaponPhysicalDamage, int weaponMagicDamage, float weaponAccuracy)
    {
        ItemName = weaponName;
        ItemCost = weaponCost;

        this.weaponPhysicalDamage = weaponPhysicalDamage;
        this.weaponMagicDamage = weaponMagicDamage;
        this.weaponAccuracy = weaponAccuracy;
    }
}
