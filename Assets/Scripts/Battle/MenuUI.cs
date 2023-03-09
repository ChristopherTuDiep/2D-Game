
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Button attackButton;
    public Button skillListButton;
    public Button runButton;

    public GameObject skillList;

    //The code controlling the attack button
    public void AttackButton() 
    {
        BattleHandler.ButtonPressed();

        if (BattleHandler.Hit())
        {
            BattleHandler.WeaponAttack();

            BattleHandler.SetDialogue("You hit!");
        }

        else
        {
            BattleHandler.SetDialogue("You miss!");
        }
    }

    //The code controlling the skill button
    public void SkillListButton()
    {
        skillList.SetActive(!skillList.activeSelf);
    }

    //the code controlling the run button
    public void RunButton()
    {
        float random = Random.value;

        BattleHandler.ButtonPressed();

        BattleHandler.TryToEscape(random);
    }

    public void DisableSkillList()
    {
        skillList.SetActive(false);
    }

}
