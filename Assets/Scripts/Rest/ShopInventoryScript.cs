using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryScript : MonoBehaviour
{
    [SerializeField] GameObject weaponList;
    [SerializeField] GameObject armorList;

    private void Start()
    {
        weaponList.SetActive(true);
        armorList.SetActive(false);
    }

    public void WeaponButton()
    {
        weaponList.SetActive(true);
        armorList.SetActive(false);
    }

    public void ArmorButton()
    {
        weaponList.SetActive(false);
        armorList.SetActive(true);
    }
}
