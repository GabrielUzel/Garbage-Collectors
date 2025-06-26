using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
  public void LoadLevelsMenuScene()
  {
    SceneManager.LoadScene("Levels_Menu_Scene");
  }
}