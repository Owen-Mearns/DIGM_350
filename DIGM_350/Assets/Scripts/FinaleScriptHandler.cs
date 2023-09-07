using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleScriptHandler : DialogueTrigger
{
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (GirdleHandler.girdleGivenBack) {
                FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue[0]);
            } else {
                FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue[1]);
            }
            Destroy(gameObject);
        }
    }
}
