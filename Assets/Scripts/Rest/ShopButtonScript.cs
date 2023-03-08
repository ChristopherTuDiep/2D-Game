using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopButtonScript : MonoBehaviour
{
    public ShopScript shopScript;
    public TMP_Text itemText;
    public TMP_Text itemCost;

    public void BuyButton()
    {
        shopScript.WantToBuy(itemText.text);
    }
}
