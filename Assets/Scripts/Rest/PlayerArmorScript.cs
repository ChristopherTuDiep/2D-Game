using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArmorScript : MonoBehaviour
{
    private List<Button> buttonList;
    private List<GameObject> buttonGOList;

    public GameObject itemButtonPrefab;
    public GameObject itemGrid;

    void Start()
    {
        buttonList = new List<Button>();
        buttonGOList = new List<GameObject>();

        for (int i = 0; i < GameBrain.Instance.armors.Count; i++)
        {

            GameObject skillButton = Instantiate(itemButtonPrefab);
            skillButton.transform.SetParent(itemGrid.transform, false);
            skillButton.GetComponent<InventoryButtonScript>().itemText.text = GameBrain.Instance.armors[i].ItemName;
            skillButton.GetComponent<InventoryButtonScript>().itemCost.text = Mathf.RoundToInt((float)GameBrain.Instance.armors[i].ItemCost / 2.0f).ToString();
            skillButton.GetComponent<Button>().interactable = (GameBrain.Instance.weapons[i].ItemAmount > GameBrain.Instance.armors[i].InUse);
            skillButton.SetActive(true);
            buttonGOList.Add(skillButton);
            buttonList.Add(skillButton.GetComponent<Button>());
        }
    }

    public void UpdateInventory()
    {
        for(int i = 0; i < buttonGOList.Count; i++)
        {
            Destroy(buttonGOList[i]);
        }

        buttonGOList.Clear();
        buttonList.Clear();

        for (int i = 0; i < GameBrain.Instance.armors.Count; i++)
        {
            GameObject skillButton = Instantiate(itemButtonPrefab);
            skillButton.transform.SetParent(itemGrid.transform, false);
            skillButton.GetComponent<InventoryButtonScript>().itemText.text = GameBrain.Instance.armors[i].ItemName;
            skillButton.GetComponent<InventoryButtonScript>().itemCost.text = Mathf.RoundToInt((float)GameBrain.Instance.armors[i].ItemCost / 2.0f).ToString();
            skillButton.GetComponent<Button>().interactable = (GameBrain.Instance.weapons[i].ItemAmount > GameBrain.Instance.armors[i].InUse);
            skillButton.SetActive(true);
            buttonGOList.Add(skillButton);
            buttonList.Add(skillButton.GetComponent<Button>());
        }
    }

}
