using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationNode : MonoBehaviour
{
    [SerializeField] public int locationID;
    [SerializeField] GameObject[] active;
    [SerializeField] GameObject currentGO;
    [SerializeField] GameObject currentMenuGO;
    [SerializeField] bool isStartLocation;
    [SerializeField] bool isBattleLocation;
    [SerializeField] bool isRestLocation;
    [SerializeField] bool isEndOfLevel;

    Button currentButton;
    private void Awake()
    {
        currentButton = GetComponent<Button>();
    }

    public void LocationButton()
    {
        currentMenuGO.GetComponent<WorldMenu>().PreviousLocation(GameBrain.Instance.location);
        currentMenuGO.GetComponent<WorldMenu>().SetBattleButton(isBattleLocation);
        GameBrain.Instance.location = locationID;
        EnableNodes();
        currentMenuGO.GetComponent<WorldMenu>().WaitForInput(isBattleLocation, isRestLocation, isEndOfLevel);
    }

    private void EnableNodes()
    {
        //this means the node this enables is not currently enabled
        if (active.Length > 0 && !GameBrain.Instance.activeIDs.Contains(active[0].GetComponent<LocationNode>().locationID))
        {
            for (int i = 0; i < active.Length; i++)
            {
                if (!isBattleLocation)
                {
                    active[i].GetComponent<Button>().interactable = true;
                }
                GameBrain.Instance.locationsToAdd.Add(active[i].GetComponent<LocationNode>().locationID);
            }
        }
    }

    private void Update()
    {
        if(isStartLocation)
        {
            currentButton.interactable = false;
        }
    }
}
