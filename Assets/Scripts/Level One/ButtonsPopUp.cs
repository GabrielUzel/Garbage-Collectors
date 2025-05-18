using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsPopUp : MonoBehaviour
{
  public void LoadLevelsMenuScene()
  {
    SceneManager.LoadScene("Levels_Menu_Scene");
  }
}
