using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHUD : MonoBehaviour
{
    public TMP_Text nameText;
    public Slider healthSlider;
    public Image fill;
    public Gradient healthGradient;
    public Slider manaSlider;
    public Image manaFill;
    public Gradient manaGradient;
    public Slider expSlider;
    public Image expFill;
    public Gradient expGradient;


    public void SetName(string name)
    {
        nameText.text = name;
    }
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        fill.color = healthGradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        healthSlider.value = health;

        fill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }

    public void SetMaxMana(int mana)
    {
        manaSlider.maxValue = mana;
        manaSlider.value = mana;

        manaFill.color = manaGradient.Evaluate(1f);
    }
    public void SetMana(int mana)
    {
        manaSlider.value = mana;

        manaFill.color = manaGradient.Evaluate(manaSlider.normalizedValue);
    }
    public void SetMaxExp(int levelUpExp)
    {
        expSlider.maxValue = levelUpExp;

        expFill.color = expGradient.Evaluate(1f);
    }

    public void SetExp(int currentExp)
    {
        expSlider.value = currentExp;

        expFill.color = expGradient.Evaluate(expSlider.normalizedValue);
    }
}
