using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopArmorScript : MonoBehaviour
{
    private List<Button> buttonList;

    [SerializeField] ShopScript shop;
    public GameObject itemButtonPrefab;
    public GameObject itemGrid;

    void Start()
    {
        buttonList = new List<Button>();

        for (int i = 0; i < shop.listOfArmors.Count; i++)
        {

            GameObject skillButton = Instantiate(itemButtonPrefab);
            skillButton.transform.SetParent(itemGrid.transform, false);
            skillButton.GetComponent<ShopButtonScript>().itemText.text = shop.listOfArmors[i].ItemName;
            skillButton.GetComponent<ShopButtonScript>().itemCost.text = shop.listOfArmors[i].ItemCost.ToString();
            skillButton.SetActive(true);
            buttonList.Add(skillButton.GetComponent<Button>());
        }
    }

    //checks if any buttons need to be set to uninteractable
    private void Update()
    {

    }

}
