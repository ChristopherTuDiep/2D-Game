using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyImageController : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;

    public void UseGold(int amount)
    {
        GameBrain.Instance.gold -= amount;
    }

    private void Update()
    {
        moneyText.text = "Gold: " + GameBrain.Instance.gold;
    }
}
