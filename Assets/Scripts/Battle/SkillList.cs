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
    private readonly float buttonSpacing = 3f;

    void Start()
    {
        buttonList = new List<Button>();
        Vector2 buttonPos;

        for (int i = 0; i < currentPlayer.GetSkills().Count; i++)
        {
            buttonPos = Vector2.zero;
            buttonPos.y = buttonY - (buttonSpacing * i);
            buttonPos.x = buttonX;

            GameObject skillButton = Instantiate(skillButtonPrefab, buttonPos, Quaternion.identity);
            skillButton.transform.SetParent(skillList.transform, false);
            skillButton.GetComponent<SkillButtonScript>().skillName.text = currentPlayer.GetSkills()[i].skillName;
            if (!currentPlayer.GetSkills()[i].isPhysical)
            {
                skillButton.GetComponent<SkillButtonScript>().skillCost.text = currentPlayer.GetSkills()[i].skillCost.ToString() + " MP";
            }
            else
            {
                skillButton.GetComponent<SkillButtonScript>().skillCost.text = 
                    Mathf.RoundToInt(((float)currentPlayer.GetSkills()[i].skillCost / 100.0f) * currentPlayer.MaxHealth()).ToString() + " HP";
            }

            buttonList.Add(skillButton.GetComponent<Button>());
        }
    }

    //checks if any buttons need to be set to uninteractable
    private void Update()
    {
        for(int i = 0; i < buttonList.Count; i++)
        {
            bool canUse = currentPlayer.CanUseSkill(currentPlayer.GetSkills()[i].skillName);
            buttonList[i].interactable = canUse;
        }
    }

}
