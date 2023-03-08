using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EquipWeaponList : MonoBehaviour
{
    private List<Button> buttonList;

    public GameObject itemButtonPrefab;
    public GameObject itemGrid;

    void Start()
    {
        buttonList = new List<Button>();

        for (int i = 0; i < GameBrain.Instance.weapons.Count; i++)
        {

            GameObject skillButton = Instantiate(itemButtonPrefab);
            skillButton.transform.SetParent(itemGrid.transform, false);
            skillButton.GetComponent<EquipListScript>().itemName.text = GameBrain.Instance.weapons[i].ItemName;
            buttonList.Add(skillButton.GetComponent<Button>());
        }
    }

    private void Update()
    {
        for(int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].interactable = !GameBrain.Instance.weapons[i].IsEquipped;
        }
    }
}
