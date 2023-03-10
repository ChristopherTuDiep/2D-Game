using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject statsDisplay;

    public void StatsButton()
    {
        statsDisplay.SetActive(!statsDisplay.activeSelf);
    }

    private void OnDisable()
    {
        statsDisplay.SetActive(false);
    }
}
