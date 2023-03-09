using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CutsceneManager
{

    public static List<Dialogue> CutsceneID(int cutsceneID)
    {
        switch (cutsceneID)
        {
            case 0:
                return Cutscene1();
            default:
                Debug.Log("This ran for some ungodly reason");
                return null;
        }
    }
    public static List<Dialogue> Cutscene1()
    {
        List<Dialogue> dialogue = new();

        Dialogue dialogue1 = new Dialogue("Owen");
        dialogue1.sentences.Add("There have been a lot of disturbances here lately, rumors say it's been caused by a sorcerer.");
        dialogue1.sentences.Add("I wonder if the rumors are true...");
        dialogue1.sentences.Add("Well, it is my job as a knight to find out, no use complaining now.");

        dialogue.Add(dialogue1);

        return dialogue;
    }
}
