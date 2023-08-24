using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public static int sceneNumber = 2;
    public static void LoadNextScene() {
        sceneNumber++;
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
    }
}
