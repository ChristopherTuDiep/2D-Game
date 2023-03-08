using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentScript : MonoBehaviour
{
    [SerializeField] StatsScript statsScript;

    [SerializeField] TMP_Text weaponText;
    [SerializeField] TMP_Text armorText;

    private void Update()
    {
        weaponText.text = statsScript.CurrentPlayer().currentWeapon.ItemName;
        armorText.text = statsScript.CurrentPlayer().currentArmor.ItemName;
    }
}
