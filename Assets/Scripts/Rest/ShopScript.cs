using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [SerializeField] RestMenuUI restMenu;
    [SerializeField] GameObject weaponList;

    public List<Weapon> listOfWeapons;

    private Weapon itemToBuy;
    private Weapon itemToSell;

    private void Awake()
    {
        listOfWeapons = new()
        {
            new Weapon(),
            new Weapon("Moonblade", 50, 1, 50, 50, 10)
        };
        weaponList.SetActive(true);
    }

    public void WeaponButton()
    {
        weaponList.SetActive(true);
    }

    public void ArmorButton()
    {
        weaponList.SetActive(false);
    }

    public void WantToBuy(string name)
    {
        var index = listOfWeapons.FindIndex(f => f.ItemName == name);
        if (index != -1)
        {
            itemToBuy = listOfWeapons[index];
            restMenu.BuyItem(itemToBuy);
        }
        else
        {
            Debug.Log("Cannot find Item");
        }
    }

    public void WantToSell(string name)
    {
        var index = GameBrain.Instance.weapons.FindIndex(f => f.ItemName == name);
        if (index != -1)
        {
            itemToSell = GameBrain.Instance.weapons[index];
            restMenu.SellItem(itemToSell);
        }
        else
        {
            Debug.Log("Cannot find Item");
        }
    }

    public void Buy()
    {
        GameBrain.Instance.AddWeapon(itemToBuy);
    }

    public void Sell()
    {
        GameBrain.Instance.SellWeapon(itemToSell);
    }

    public void Cancelled()
    {
        itemToBuy = null;
    }
}
