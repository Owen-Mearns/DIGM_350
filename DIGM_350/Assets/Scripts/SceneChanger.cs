using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public string nextScene;
    public void LoadNextScene() {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
