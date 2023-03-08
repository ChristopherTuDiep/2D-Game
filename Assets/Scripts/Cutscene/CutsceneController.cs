using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] TMP_Text talkerName;
    [SerializeField] TMP_Text dialogue;

    private bool mouseClicked;

    private string currentTalker;
    private string currentDialogue;
    // Start is called before the first frame update
    void Start()
    {
        mouseClicked = false;
        CutsceneFinder(0);
    }

    private void CutsceneFinder(int cutsceneID)
    {
        switch (cutsceneID)
        {
            case 0:
                StartCoroutine(Cutscene1());
                break;
            default:
                break;
        }
    }
    IEnumerator Cutscene1()
    {
        currentTalker = "Professor Oak";
        currentDialogue = "Welcome to the world of pokemon!";

        yield return new WaitUntil(CanContinueCutscene);

        mouseClicked = false;
        currentDialogue = "This is a fantastic world with wonderful creatures called pokemon";

        yield return new WaitUntil(CanContinueCutscene);
        mouseClicked = false;

        currentTalker = "You";
        currentDialogue = "Thank you!";
    }

    private bool CanContinueCutscene() => mouseClicked;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseClicked = true;
        }

        talkerName.text = currentTalker;
        dialogue.text = currentDialogue;
    }
}
