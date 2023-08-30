using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseScreen;

    private bool isPaused = false;
    private ChoiceCanvasScript scriptComponent; // Replace YourScriptComponent with the actual script type you want to enable

    void Start()
    {
        PauseScreen.SetActive(false);
        scriptComponent = PauseScreen.GetComponent<ChoiceCanvasScript>(); // Replace YourScriptComponent
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            Resume();
        }
    }

    void PauseGame()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0;

        if (scriptComponent != null)
        {
            scriptComponent.enabled = true;
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);

        if (scriptComponent != null)
        {
            scriptComponent.enabled = false;
        }
    }
}


