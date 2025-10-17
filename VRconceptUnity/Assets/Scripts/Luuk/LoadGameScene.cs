using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    // The name of the scene you want to load (set this in the Inspector)
    [SerializeField] private string sceneName = "GameScene";

    // This function can be called by the UI Button OnClick event
    public void LoadScene()
    {
        // Check if sceneName is valid
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set in the Inspector!");
        }
    }

    // Optional: You can also create a quit button
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
