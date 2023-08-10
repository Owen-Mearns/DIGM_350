using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText, dialogueText;
    private Queue<string> sentences;
    [SerializeField] private GameObject dialogueCanvas;
    private void Start() {
        sentences = new Queue<string>();
        Cursor.lockState = CursorLockMode.Locked;
        dialogueCanvas.SetActive(false);
    }
    public void StartDialogue(Dialogue dialogue) {
        Cursor.lockState = CursorLockMode.None;
        dialogueCanvas.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            Cursor.lockState = CursorLockMode.Locked;
            dialogueCanvas.SetActive(false);
            Movement.interacting = false;
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

}
