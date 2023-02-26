using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBrain : Singleton<GameBrain>
{
    private List<Player> playerData;

    // Start is called before the first frame update
    private void Start()
    {
        print("This should get called first");
        playerData = new List<Player>();
        Player warrior = new Player("Warrior", 1, 10, 500, 1, 5, 3, 5);
        playerData.Add(warrior);
    }

    public void EmptyRun()
    {
        ;
    }

    public void SetStats(Player player, int increment)
    {
        player.SetPlayerStats(playerData[increment]);
    }

    public void UpdateStats(Player[] players)
    {
        for(int i = 0; i < playerData.Count; i++)
        {
            playerData[i].SetPlayerStats(players[i]);
        }
    }

    public Player GetPlayer(int i)
    {
        return playerData[i];
    }

    public int PlayerCount()
    {
        return playerData.Count;
    }
}
