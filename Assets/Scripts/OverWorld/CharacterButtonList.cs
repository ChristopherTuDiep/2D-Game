using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonList : MonoBehaviour
{
    private List<Button> buttonList;

    public GameObject itemButtonPrefab;
    public GameObject itemGrid;

    void Start()
    {
        buttonList = new List<Button>();

        for (int i = 0; i < GameBrain.Instance.PlayerCount(); i++)
        {

            GameObject skillButton = Instantiate(itemButtonPrefab);
            skillButton.transform.SetParent(itemGrid.transform, false);
            skillButton.GetComponentInChildren<CharacterButtonUI>().characterNumber.text = (i + 1).ToString();
            skillButton.GetComponent<CharacterButtonUI>().numberInList = i;
            skillButton.SetActive(true);
            buttonList.Add(skillButton.GetComponent<Button>());
        }
    }
}
