using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillButtonScript : MonoBehaviour
{
    public GameObject skillButton;
    public TMP_Text skillName;
    public TMP_Text skillCost;

    public void SkillButton()
    {
        BattleHandler.ButtonPressed();

        BattleHandler.ActivateSkill(skillButton.GetComponentInChildren<TMP_Text>().text);
    }
}
