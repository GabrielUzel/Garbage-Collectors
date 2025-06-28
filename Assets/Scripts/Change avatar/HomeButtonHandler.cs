using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonHandler : MonoBehaviour
{
  public void LoadMainMenuScene()
  {
    SceneManager.LoadScene("Main_Menu_Scene");
  }
}
