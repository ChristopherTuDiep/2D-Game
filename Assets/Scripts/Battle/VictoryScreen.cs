using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] TMP_Text goldGained;
    [SerializeField] TMP_Text expGained;

    public GameObject characterHudPrefab;

    private readonly float characterBarXPos = 200f;
    private readonly float characterBarYPos = 90f;

    private void Start()
    {
        for(int i = 0; i < GameBrain.Instance.PlayerCount(); i++)
        {
            Vector2 hudPositioning = new Vector2(); 
            if(i % 2 == 0)
            {
                hudPositioning.x = -characterBarXPos;
            }
            else
            {
                hudPositioning.x = -characterBarXPos;
            }

            if(i < 2)
            {
                hudPositioning.y = characterBarYPos;
            }
            else
            {
                hudPositioning.y = -characterBarYPos;
            }
        }
    }
}
