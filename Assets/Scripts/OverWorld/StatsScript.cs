using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
    [SerializeField] GeneralCharacterInfoScript generalCharacterInfo;
    [SerializeField] EquipmentScript equipmentScript;
    [SerializeField] AttributesScript attributesScript;

    [SerializeField] GameObject weaponList;
    [SerializeField] GameObject armorList;

    private EntityData currentEntity;

    private void Start()
    {
        currentEntity = GameBrain.Instance.GetPlayerData(0);
        generalCharacterInfo.UpdateStats(currentEntity);
        attributesScript.UpdateAttributes(currentEntity);
        weaponList.SetActive(false);
        armorList.SetActive(false);
    }

    public void WeaponButton()
    {
        weaponList.SetActive(!weaponList.activeSelf);
        armorList.SetActive(false);
    }

    public void ArmorButton()
    {
        weaponList.SetActive(false);
        armorList.SetActive(!armorList.activeSelf);
    }

    public void SetEntity(EntityData newEntity)
    {
        currentEntity = newEntity;
        weaponList.SetActive(false);
        armorList.SetActive(false);
    }

    public EntityData CurrentPlayer()
    {
        return currentEntity;
    }

    private void Update()
    {
        generalCharacterInfo.UpdateStats(currentEntity);
        attributesScript.UpdateAttributes(currentEntity);
    }
}
