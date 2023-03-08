using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestDialogueController : MonoBehaviour
{
    [SerializeField] TMP_Text dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue.text = "Welcome!";
    }

    public void RestDialogue()
    {
        dialogue.text = "Would you like to stay at the inn for 10 GP?";
    }

    public void SuccessfulRest()
    {
        GameBrain.Instance.FullRest();
        dialogue.text = "You rested successfully!";
    }

    public void FailedRest()
    {
        dialogue.text = "Thank you for visiting.";
    }

    public void WaitingToBuy(string itemName)
    {
        dialogue.text = "Would you like to buy a " + itemName + "?";
    }

    public void WaitingToSell(string itemName, int sellCost)
    {
        dialogue.text = "Would you like to sell a " + itemName + " for " + sellCost+ "?";
    }

    public void SucessfulBuy()
    {
        dialogue.text = "Thank you for your purchase.";
    }

    public void FailedBuy()
    {
        dialogue.text = "Maybe something else then?";
    }
}
