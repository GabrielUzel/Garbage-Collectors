using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void LoadLevelsMenuScene()
    {
        SceneManager.LoadSceneAsync("Levels_Menu_Scene");
    }
}