
using TMPro;
using UnityEngine;

public class EquipItemScript : MonoBehaviour
{
    [SerializeField] public TMP_Text itemName;
    [SerializeField] StatsScript currentStats;

    public void EquipButtonPressed()
    {
        var index = GameBrain.Instance.weapons.FindIndex(f => f.ItemName.Equals(itemName.text));
        if(index != -1)
        {
            currentStats.CurrentPlayer().EquipWeapon(GameBrain.Instance.weapons[index]);
            return;
        }

        index = GameBrain.Instance.armors.FindIndex(f => f.ItemName.Equals(itemName.text));
        if (index != -1)
        {
            currentStats.CurrentPlayer().EquipArmor(GameBrain.Instance.armors[index]);
        }
    }
}
