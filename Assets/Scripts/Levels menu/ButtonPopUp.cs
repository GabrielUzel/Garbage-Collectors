using UnityEngine;
using UnityEngine.UI;

public class ButtonPopUp : MonoBehaviour
{
  public void StartButton(Text LevelText)
  {
    if (LevelText.text == "1")
    {
      bool tutorialAlreadyShown = PlayerPrefs.GetInt("TutorialShown_Level1", 0) == 1;

      if (!tutorialAlreadyShown)
      {
        PlayerPrefs.SetInt("TutorialShown_Level1", 1);
        PlayerPrefs.SetInt("PlayingLevel1AfterTutorial", 1);
        PlayerPrefs.Save();
        SceneLoader.LoadScene("Tutorial_Scene");
        return;
      }
    }

    SceneLoader.LoadScene("Gameplay_Scene");
  }
}
