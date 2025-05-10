using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void LoadLevelsMenuScene()
    {
        // Verify if there is a save file
        // If there is, load the levels menu scene
        // If not, create a new save file and set the current level to 1
        SceneManager.LoadScene("Levels_Menu_Scene");
    }
}