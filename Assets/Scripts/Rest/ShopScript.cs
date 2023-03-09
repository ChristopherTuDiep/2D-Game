using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [SerializeField] RestMenuUI restMenu;
    [SerializeField] PlayerWeaponScript playerWeaponList;
    [SerializeField] PlayerArmorScript playerArmorList;

    public List<Weapon> listOfWeapons;
    public List<Armor> listOfArmors;

    private Weapon weaponToBuy;
    private Weapon weaponToSell;

    private Armor armorToBuy;
    private Armor armorToSell;

    private void Awake()
    {
        listOfWeapons = new()
        {
            new Weapon(),
            new Weapon("Moonblade", 50, 1, 50, 50, 10)
        };

        listOfArmors = new()
        {
            new Armor(),
            new Armor("Iron Armor", 20, 1, 10, 10)
        };
    }

    public void WantToBuy(string name)
    {
        var index = listOfWeapons.FindIndex(f => f.ItemName == name);
        if (index != -1)
        {
            weaponToBuy = listOfWeapons[index];
            restMenu.BuyItem(weaponToBuy);
            return;
        }

        index = listOfArmors.FindIndex(f => f.ItemName == name);
        if (index != -1)
        {
            armorToBuy = listOfArmors[index];
            restMenu.BuyItem(armorToBuy);
            return;
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
            weaponToSell = GameBrain.Instance.weapons[index];
            restMenu.SellItem(weaponToBuy);
            return;
        }

        index = GameBrain.Instance.armors.FindIndex(f => f.ItemName == name);
        if (index != -1)
        {
            armorToSell = GameBrain.Instance.armors[index];
            restMenu.SellItem(armorToSell);
            return;
        }
    }

    public void Buy()
    {
        if(weaponToBuy != null)
        {
            GameBrain.Instance.AddWeapon(weaponToBuy);
            playerWeaponList.UpdateInventory();
        }
        else if (armorToBuy != null)
        {
            GameBrain.Instance.AddArmor(armorToBuy);
            playerArmorList.UpdateInventory();
        }
    }

    public void Sell()
    {
        if(weaponToSell != null)
        {
            GameBrain.Instance.SellWeapon(weaponToSell);
            playerWeaponList.UpdateInventory();
        }
        else if (armorToSell != null)
        {
            GameBrain.Instance.SellArmor(armorToSell);
            playerArmorList.UpdateInventory();
        }
    }

    public void Cancelled()
    {
        weaponToBuy = null;
        weaponToSell = null;
        armorToBuy = null;
        armorToSell = null;
    }
}
