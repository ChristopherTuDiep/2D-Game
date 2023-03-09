using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue
{
    public string name;
    public List<string> sentences;

    public Dialogue(string name)
    {
        sentences = new();
        this.name = name;
    }
}

