using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterButtonUI : MonoBehaviour
{
    [SerializeField] public TMP_Text characterNumber;
    [SerializeField] StatsScript statsScript;

    public int numberInList;

    public void CharacterButton()
    {
        Debug.Log("Got entity at " + numberInList);
        statsScript.SetEntity(GameBrain.Instance.GetPlayerData(numberInList));
    }
}
