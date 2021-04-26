using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>(); 
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        Debug.Log("text count "+sentences.Count);
        string sentence=sentences.Dequeue();
        dialogueText.text = sentence;
    }


    void EndDialogue()
    {
        GameObject.Find("TransitionScreen").GetComponent<Animator>().enabled = true;
        Invoke("GoBackToTitleScreen", 2.0f);

    }
    void GoBackToTitleScreen()
    {
        SceneManager.LoadScene("Title");
    }
}
