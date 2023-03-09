using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameBrain : Singleton<GameBrain>
{
    private List<EntityData> playerData;
    public int location;
    public List<int> locationsToAdd;
    public List<int> activeIDs;
    public List<Weapon> weapons;
    public List<Armor> armors;
    public List<IConsumable> consumables;
    public int gold;
    public string returnScene;
    public int cutsceneID;

    // Start is called before the first frame update
    private void Start()
    {
        returnScene = "World_Scene";
        cutsceneID = 0;
        location = 0;
        locationsToAdd = new();
        gold = 100;
        playerData = new List<EntityData>();
        activeIDs = new List<int>();
        List<Skill> skills = new()
        {
            new Skill("Cleave", 10, 200, true),
            new Skill("Agi", 4, 100, false)
        };
        weapons = new()
        {
            new Weapon(),
            new Weapon("Excalibur", 1000, 1, 100, 100, 10)
        };
        armors = new()
        {
            new Armor()
        };
        consumables = new()
        {
            new HealthPotion()
        };

        EntityData warrior = new("Warrior", 1, true, 10, 5, 10, 3, 10, 3, 10, 3, 5, 10, skills, 0);

        warrior.EquipWeapon(weapons[0]);

        playerData.Add(warrior);
        playerData.Add(new());
    }

    public void EmptyRun()
    {
        ;
    }

    public void AddLocations()
    {
        for(int i = 0; i < locationsToAdd.Count; i++)
        {
            activeIDs.Add(locationsToAdd[i]);
        }
    }

    public void Initialize(GameObject[] active)
    {
        bool isEmpty = !activeIDs.Any();
        if(isEmpty)
        {
            for(int i = 0; i < active.Length; i++)
            {
                activeIDs.Add(active[i].GetComponent<LocationNode>().locationID);
            }
        }
    }

    public void AddWeapon(Weapon newWeapon)
    {
        var index = weapons.FindIndex(f => f.ItemName == newWeapon.ItemName);
        if (index != -1)
        {
            weapons[index].ItemAmount++;
        }
        else
        {
            weapons.Add(newWeapon);
        }
    }

    public void SellWeapon(Weapon weapon)
    {
        var index = weapons.FindIndex(f => f.ItemName == weapon.ItemName);
        if (index != -1)
        {
            weapons[index].ItemAmount--;
            if (weapons[index].ItemAmount <= 0)
            {
                weapons.Remove(weapons[index]);
            }
        }
        else
        {
            Debug.Log("Weapon not found");
        }
    }

    public void AddArmor(Armor newArmor)
    {
        var index = weapons.FindIndex(f => f.ItemName == newArmor.ItemName);
        if (index != -1)
        {
            armors[index].ItemAmount++;
        }
        else
        {
            armors.Add(newArmor);
        }
    }

    public void SellArmor(Armor armor)
    {
        var index = weapons.FindIndex(f => f.ItemName == armor.ItemName);
        if (index != -1)
        {
            armors[index].ItemAmount--;
            if (weapons[index].ItemAmount <= 0)
            {
                armors.Remove(armors[index]);
            }
        }
        else
        {
            Debug.Log("Armor not found");
        }
    }

    public void RestartWorld()
    {
        activeIDs.Clear();
    }

    public EntityData GetStats(string playerName) 
    {
        var matches = playerData.Where(p => p.EntityName == playerName);
        return (EntityData)matches;
    }

    public void SetStats(Player player, int increment)
    {
        player.SetData(playerData[increment]);
    }

    public void UpdateStats(Player[] players)
    {
        for(int i = 0; i < playerData.Count; i++)
        {
            playerData[i].CopyData(players[i].GetPlayerData());
        }
    }
    public EntityData GetPlayerData(int i)
    {
        return playerData[i];
    }

    public int PlayerCount()
    {
        return playerData.Count;
    }

    public void FullRest()
    {
        for(int i = 0; i < playerData.Count; i++)
        {
            playerData[i].FullRestore();
        }
    }

}
