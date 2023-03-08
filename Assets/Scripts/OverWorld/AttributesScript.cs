using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttributesScript : MonoBehaviour
{
    [SerializeField] TMP_Text phyAttack;
    [SerializeField] TMP_Text magAttack;
    [SerializeField] TMP_Text phyDefense;
    [SerializeField] TMP_Text magDefense;
    [SerializeField] TMP_Text accuracy;
    [SerializeField] TMP_Text speed;
    [SerializeField] TMP_Text critical;
    [SerializeField] TMP_Text evasion;

    private EntityData currentData;
    public void UpdateAttributes(EntityData data)
    {
        currentData = data;
    }

    private void Update()
    {
        phyAttack.text = (currentData.PhyAttack + currentData.currentWeapon.physicalAtk).ToString();
        magAttack.text = (currentData.MagAttack + currentData.currentWeapon.magicAtk).ToString();
        phyDefense.text = (currentData.PhyDefense + currentData.currentArmor.phyDefense).ToString();
        magDefense.text = (currentData.MagDefense + currentData.currentArmor.magDefense).ToString();
        accuracy.text = currentData.Accuracy.ToString();
        speed.text = currentData.Speed.ToString();
        critical.text = currentData.Critical.ToString();
        evasion.text = currentData.Evasion.ToString();
    }
}
