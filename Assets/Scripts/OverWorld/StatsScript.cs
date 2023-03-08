using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
    [SerializeField] GeneralCharacterInfoScript generalCharacterInfo;
    [SerializeField] EquipmentScript equipmentScript;
    [SerializeField] AttributesScript attributesScript;

    [SerializeField] GameObject weaponList;

    private EntityData currentEntity;

    private void Start()
    {
        currentEntity = GameBrain.Instance.GetPlayerData(0);
        generalCharacterInfo.UpdateStats(currentEntity);
        attributesScript.UpdateAttributes(currentEntity);
        weaponList.SetActive(false);
    }

    public void WeaponButton()
    {
        weaponList.SetActive(!weaponList.activeSelf);
    }

    public EntityData CurrentPlayer()
    {
        return currentEntity;
    }
}
