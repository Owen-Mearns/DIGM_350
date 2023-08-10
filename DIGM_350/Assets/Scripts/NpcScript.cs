using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    [SerializeField] public Dialogue dialogue;
    public void TriggerDialogue() {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }

}
