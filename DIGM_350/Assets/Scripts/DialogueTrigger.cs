using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private int timesTalkedTo = 0;
    [SerializeField] public Dialogue[] dialogue;
    public void TriggerDialogue() {
        timesTalkedTo++;
        if (ItemManager.quotaSatisfied) {
            FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue[1]);
            return;
        }
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue[0]);
    }

}
