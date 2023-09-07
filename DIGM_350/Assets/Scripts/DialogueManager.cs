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
    private bool foundChangeTrigger, foundChoiceTrigger = false;
    [SerializeField] public GameObject choiceButtonCanvas;
    [SerializeField] public GameObject sceneChanger;

    private void Start() {
        sentences = new Queue<string>();
        Cursor.lockState = CursorLockMode.Locked;
        dialogueCanvas.SetActive(false);
    }
    public void StartDialogue(Dialogue dialogue) {
        //START DIALOGUE STATE
        foundChangeTrigger = dialogue.sceneChangeTrigger;
        foundChoiceTrigger = dialogue.optionTrigger;
        Cursor.lockState = CursorLockMode.None;
        dialogueCanvas.SetActive(true);
        PlayerCam.locked = true;
        //--
        nameText.text = dialogue.name;//Name tag
        sentences.Clear();
        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            if (foundChangeTrigger) sceneChanger.GetComponent<SceneChanger>().LoadNextScene();
            //RESUME GAME STATE--
            Cursor.lockState = CursorLockMode.Locked;
            dialogueCanvas.SetActive(false);
            PlayerScript.interacting = false;
            PlayerCam.locked = false;
            //--
            if (foundChoiceTrigger) {
                choiceButtonCanvas.SetActive(true);
            }
            return;
        }
        //DISPLAY TEXT
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        //--
    }

}
