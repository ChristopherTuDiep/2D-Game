using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;

    private Queue<Dialogue> dialogueQueue;
    private Queue<string> sentences;
    void Start()
    {
        dialogueQueue = new Queue<Dialogue>();
        sentences = new Queue<string>();
        RunDialogue(CutsceneManager.CutsceneID(0));
    }

    public void RunDialogue(List<Dialogue> dialogueList)
    {
        foreach (Dialogue dialogue in dialogueList)
        {
            dialogueQueue.Enqueue(dialogue);
        }

        StartDialogue(dialogueQueue.Dequeue());
    }

    public void StartDialogue (Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0 && dialogueQueue.Count != 0)
        {
            StartDialogue(dialogueQueue.Dequeue());
        }
        else if(dialogueQueue.Count == 0 && sentences.Count ==0)
        {
            EndDialogue();
            return;
        }
        else
        {
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(GameBrain.Instance.returnScene);
    }
}
