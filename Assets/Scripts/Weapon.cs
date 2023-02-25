using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public int weaponDamage;
    public float weaponAccuracy;

    public Weapon()
    {
        weaponDamage = 38;
        weaponAccuracy = 0.9f;
    }

    public Weapon(int weaponDamage, float weaponAccuracy)
    {
        this.weaponDamage = weaponDamage;
        this.weaponAccuracy = weaponAccuracy;
    }
}
