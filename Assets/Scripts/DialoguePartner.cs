using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialoguePartner : MonoBehaviour 
{
    public TextMeshProUGUI DialogueText;

    private Queue<string> Sentences;

    void Start()
    {
        DialogueText.enabled = false;

        DialogueText.gameObject.SetActive(false);

        Sentences = new Queue<string>();
    }

    public void StartDialogue(string[] Dialogue)
    {
        DialogueText.enabled = true;

        DialogueText.gameObject.SetActive(true);
        
        Sentences.Clear();

        foreach (string Sentence in Dialogue)
        {
            Sentences.Enqueue(Sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndDialogue();

            return;
        }

        string Sentence = Sentences.Dequeue();

        DialogueText.text = Sentence;
    }

    void EndDialogue()
    {
        StartCoroutine(HideDialogue());
    }

    IEnumerator HideDialogue()
    {
        yield return new WaitForSeconds(10.0f);

        DialogueText.enabled = false;

        DialogueText.gameObject.SetActive(false);
    }
}