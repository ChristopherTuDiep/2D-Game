using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestMenuUI : MonoBehaviour
{
    [SerializeField] Button restButton;
    [SerializeField] RestDialogueController dialogueController;
    [SerializeField] MoneyImageController moneyImageController;
    [SerializeField] GameObject yesButton;
    [SerializeField] GameObject noButton;

    [SerializeField] GameObject shop;

    private bool waitingForInput;
    private int costAmount;
    private bool restInput;
    private bool shopBuyInput;
    private bool shopSellInput;
    private void Start()
    {
        waitingForInput = false;
        restInput = false;
        costAmount = 0;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        shop.SetActive(false);
    }
    private void WaitForInput(bool waiting)
    {
        waitingForInput = waiting;
        yesButton.SetActive(waiting);
        noButton.SetActive(waiting);
    }
    public void RestButton()
    {
        costAmount = 10;
        restInput = true;
        dialogueController.RestDialogue();
        WaitForInput(true);
    }
    public void ShopButton()
    {
        shop.SetActive(!shop.activeSelf);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("World_Scene");
    }

    public void YesButton()
    {
        if (restInput)
        {
            moneyImageController.UseGold(costAmount);
            dialogueController.SuccessfulRest();
        }
        else if(shopBuyInput)
        {
            moneyImageController.UseGold(costAmount);
            shop.GetComponent<ShopScript>().Buy();
            dialogueController.SucessfulBuy();
        }
        else if (shopSellInput)
        {
            moneyImageController.UseGold(-costAmount);
            shop.GetComponent<ShopScript>().Sell();
            dialogueController.SucessfulBuy();
        }
        restInput = false;
        shopBuyInput = false;
        shopSellInput = false;
        WaitForInput(false);
    }

    public void NoButton()
    {
        if(restInput)
        {
            dialogueController.FailedRest();
        }
        else if(shopBuyInput) 
        {
            shop.GetComponent<ShopScript>().Cancelled();
            dialogueController.FailedBuy();
        }
        else if (shopSellInput)
        {
            shop.GetComponent<ShopScript>().Cancelled();
            dialogueController.FailedBuy();
        }
        restInput = false;
        shopBuyInput = false;
        shopSellInput = false;
        WaitForInput(false);
    }
    public void BuyItem(Item item)
    {
        shopBuyInput = true;
        costAmount = item.ItemCost;
        dialogueController.WaitingToBuy(item.ItemName);
        WaitForInput(true);
    }

    public void SellItem(Item item)
    {
        shopSellInput = true;
        costAmount = Mathf.RoundToInt((float)item.ItemCost / 2.0f);
        dialogueController.WaitingToSell(item.ItemName, costAmount);
        WaitForInput(true);
    }

    private void Update()
    {
        restButton.enabled = !waitingForInput;
    }
}
