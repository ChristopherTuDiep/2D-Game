using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    //These three buttons occupy the same space because all of them should never been on the menu at the same time.
    [SerializeField] GameObject battleButton;
    [SerializeField] GameObject restButton;
    [SerializeField] GameObject inventoryButton;
    [SerializeField] GameObject leaveLevel;

    [SerializeField] GameObject inventory;
    [SerializeField] GameObject stats;

    int previousLocation;
    bool isBattleButton;
    // Start is called before the first frame update
    void Awake()
    {
        isBattleButton = false;
        previousLocation = 0;
        menu.SetActive(false);
        battleButton.SetActive(false);
        inventory.SetActive(false);
        stats.SetActive(false);
        restButton.SetActive(false);
    }

    public void SetBattleButton(bool battleButton)
    {
        isBattleButton = battleButton;
    }

    public void BattleButton()
    {
        SceneManager.LoadScene("Battle_Scene");
    }

    public void RestButton()
    {
        SceneManager.LoadScene("Rest_Scene");
    }

    public void InventoryButton()
    {
        stats.SetActive(false);
        inventory.SetActive(!inventory.activeSelf);
    }
    public void StatsButton()
    {
        inventory.SetActive(false);
        stats.SetActive(!stats.activeSelf);
    }
    public void ExitButton()
    {
        if(isBattleButton)
        {
            GameBrain.Instance.location = previousLocation;
        }
        DisableAll();
    }

    public void PreviousLocation(int location)
    {
        previousLocation = location;
    }

    public void WaitForInput(bool isBattleLocation, bool isRestLocation, bool isEndOfLevel)
    {
        battleButton.SetActive(isBattleLocation);
        restButton.SetActive(isRestLocation);
        menu.SetActive(true);
    }

    //Disables everything in the menu
    private void DisableAll()
    {
        isBattleButton = false;
        battleButton.SetActive(false);
        restButton.SetActive(false);
        menu.SetActive(false);
    }
    //Disables all previous opened menus when a new one is opened up
}
