using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirdleHandler : DialogueTrigger
{
    public static bool girdleGivenBack = false;
    new public void TriggerDialogue() {
        girdleGivenBack = true;
        base.TriggerDialogue();
    }
    }
