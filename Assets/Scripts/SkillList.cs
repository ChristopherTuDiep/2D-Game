using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;

public class SkillList : MonoBehaviour
{
    private List<Button> buttonList;

    public Player currentPlayer;
    public GameObject skillButtonPrefab;
    public GameObject skillList;

    private readonly float buttonX = 4.5f;
    private readonly float buttonY = 1f;
    private readonly float buttonSpacing = 1f;

    void Start()
    {
        buttonList = new List<Button>();
        Vector2 buttonPos;

        for (int i = 0; i < currentPlayer.skills.Count; i++)
        {
            buttonPos = Vector2.zero;
            buttonPos.y = buttonY - (buttonSpacing * i);
            buttonPos.x = buttonX;

            GameObject skillButton = Instantiate(skillButtonPrefab, buttonPos, Quaternion.identity);
            skillButton.transform.SetParent(skillList.transform, false);
            skillButton.GetComponent<SkillButtonScript>().skillName.text = currentPlayer.skills[i].skillName;
            skillButton.GetComponent<SkillButtonScript>().skillCost.text = currentPlayer.skills[i].skillCost.ToString() + " MP";

            buttonList.Add(skillButton.GetComponent<Button>());
        }

        skillList.SetActive(false);
    }

    //checks if any buttons need to be set to uninteractable
    private void Update()
    {
        for(int i = 0; i < buttonList.Count; i++)
        {
            bool canUse = currentPlayer.CanUseSkill(currentPlayer.skills[i].skillName);
            buttonList[i].interactable = canUse;
        }
    }

}
