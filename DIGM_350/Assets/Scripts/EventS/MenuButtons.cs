using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public List<GameObject> images = new List<GameObject>();
   
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextPage()
    {
        if (images.Count < 1)
        {
            SceneManager.LoadScene(2);
        }

        if (images.Count > 0)
        {
            images[0].gameObject.SetActive(true);
            images.Remove(images[0]);
        }

        
       
    }
}

