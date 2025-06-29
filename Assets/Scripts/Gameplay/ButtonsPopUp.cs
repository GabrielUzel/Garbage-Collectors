using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsPopUp : MonoBehaviour
{
  public void LoadLevelsMenuScene()
  {
    MusicController.Instance.IncreaseMusicVolume();
    SceneLoader.LoadScene("Levels_Menu_Scene");
  }

  public void RetryCurrentLevel()
  {
    SceneLoader.LoadScene(SceneManager.GetActiveScene().name);
  }
}
