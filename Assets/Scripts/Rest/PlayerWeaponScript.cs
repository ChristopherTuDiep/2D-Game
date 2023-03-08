using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponScript : MonoBehaviour
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
            skillButton.GetComponent<InventoryButtonScript>().itemText.text = GameBrain.Instance.weapons[i].ItemName;
            skillButton.GetComponent<InventoryButtonScript>().itemCost.text = Mathf.RoundToInt((float)GameBrain.Instance.weapons[i].ItemCost / 2.0f).ToString();
            skillButton.GetComponent<Button>().interactable = !GameBrain.Instance.weapons[i].IsEquipped;
            skillButton.SetActive(true);
            buttonList.Add(skillButton.GetComponent<Button>());
        }
    }

    //checks if any buttons need to be set to uninteractable
    private void Update()
    {
        
    }

}
