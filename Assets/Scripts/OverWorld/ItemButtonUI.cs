using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemButtonUI : MonoBehaviour
{
    public GameObject itemButton;
    public TMP_Text itemText;
    public TMP_Text itemAmount;

    public void SkillButton()
    {
        BattleHandler.ButtonPressed();

    }
}
