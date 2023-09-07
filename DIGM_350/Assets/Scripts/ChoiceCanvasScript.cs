using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCanvasScript : MonoBehaviour
{
    private void OnEnable() {
        //Debug.Log("called lol");
        PlayerCam.locked = true;
        PlayerScript.interacting = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnDisable() {
        PlayerScript.interacting = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerCam.locked = false;
    }


}
