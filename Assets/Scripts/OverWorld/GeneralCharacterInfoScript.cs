using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneralCharacterInfoScript : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider healthSlider;
    public Image fill;
    public TMP_Text healthText;
    public Gradient healthGradient;
    public Slider manaSlider;
    public Image manaFill;
    public TMP_Text manaText;
    public Gradient manaGradient;
    public TMP_Text expToLevelUp;

    public void UpdateStats(EntityData data)
    {
        nameText.text = data.EntityName;
        levelText.text = "Lv. " + data.EntityLevel;

        healthSlider.maxValue = data.MaxHealthPoints;
        healthSlider.value = data.CurrentHealthPoints;
        healthText.text = "HP: " + data.CurrentHealthPoints + "/" + data.MaxHealthPoints;

        fill.color = healthGradient.Evaluate(1f);

        manaSlider.maxValue = data.MaxSpellPoints;
        manaSlider.value = data.CurrentSpellPoints;
        manaText.text = "SP: " + data.CurrentSpellPoints + "/" + data.MaxSpellPoints;

        manaFill.color = manaGradient.Evaluate(1f);

        expToLevelUp.text = "To Next Level: 12";
    }
}
