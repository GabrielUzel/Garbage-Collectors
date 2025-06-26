using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsPopUp : MonoBehaviour
{
  public void LoadLevelsMenuScene()
  {
    MusicController.Instance.IncreaseMusicVolume();
    SceneManager.LoadScene("Levels_Menu_Scene");
  }

  public void RetryCurrentLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
