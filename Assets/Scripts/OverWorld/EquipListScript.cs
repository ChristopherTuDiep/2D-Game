using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipListScript : MonoBehaviour
{
    [SerializeField] public TMP_Text itemName;

    public void EquipButtonPressed()
    {
        var index = GameBrain.Instance.weapons.FindIndex(f => f.ItemName.Equals(itemName.text));
        if(index != -1)
        {
            GameBrain.Instance.GetPlayerData(0).EquipWeapon(GameBrain.Instance.weapons[index]);
        }
    }
}
