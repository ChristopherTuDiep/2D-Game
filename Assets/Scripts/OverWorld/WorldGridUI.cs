using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldGridUI : MonoBehaviour
{
    [SerializeField] GameObject[] startActive;
    [SerializeField] GameObject[] allNodes;
    [SerializeField] GameObject worldMenu;

    private bool[] isActive;
    private GameObject locationArrow;

    private readonly float arrowYSpacing = 0.4f;
    private void Start()
    {
        GameBrain.Instance.Initialize(startActive);

        locationArrow = Instantiate(GameAssets.instance.locationArrow);

        isActive = new bool[allNodes.Length];

        for (int i = 0; i < GameBrain.Instance.activeIDs.Count; i++)
        {
            isActive[GameBrain.Instance.activeIDs[i]] = true;
        }
    }

    private void Update()
    {
        Vector2 arrowPos = allNodes[GameBrain.Instance.location].transform.position;
        arrowPos.y += arrowYSpacing;

        locationArrow.transform.position = arrowPos;

        for (int i = 0; i < isActive.Length; i++)
        {
            allNodes[i].GetComponent<Button>().interactable = isActive[i];
        }

        for(int i = 0; i < allNodes.Length; i++)
        {
            allNodes[i].GetComponent<Button>().enabled = !worldMenu.activeSelf;
        }
    }
}
