using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPopUp : MonoBehaviour
{
  public void StartButton(Text LevelText)
  {
    SceneManager.LoadScene("Level_One_Scene");
  }
}
