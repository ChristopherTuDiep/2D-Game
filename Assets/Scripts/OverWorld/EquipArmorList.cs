using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EquipArmorList : MonoBehaviour
{
    private List<Button> buttonList;

    public GameObject itemButtonPrefab;
    public GameObject itemGrid;

    void Start()
    {
        buttonList = new List<Button>();

        for (int i = 0; i < GameBrain.Instance.armors.Count; i++)
        {

            GameObject skillButton = Instantiate(itemButtonPrefab);
            skillButton.transform.SetParent(itemGrid.transform, false);
            skillButton.GetComponent<EquipItemScript>().itemName.text = GameBrain.Instance.armors[i].ItemName;
            skillButton.SetActive(true);
            buttonList.Add(skillButton.GetComponent<Button>());
        }
    }

    private void Update()
    {
        for(int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].interactable = (GameBrain.Instance.armors[i].ItemAmount > GameBrain.Instance.armors[i].InUse);
        }
    }
}
