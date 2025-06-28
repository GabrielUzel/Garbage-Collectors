using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using TMPro; 

public class TutorialVideoHandler : MonoBehaviour
{
  public VideoPlayer videoPlayer;    
  public GameObject homeButton;       
  public GameObject fadedBackground;     
  public TMP_Text countdownText;         

  void Start()
  {
    if (PlayerPrefs.GetInt("PlayingLevel1AfterTutorial", 0) == 1 && homeButton != null)
    {
      homeButton.SetActive(false);
    }

    if (videoPlayer != null)
    {
      videoPlayer.loopPointReached += OnVideoFinished;
    }

    if (countdownText != null)
    {
      countdownText.gameObject.SetActive(false);
    }
  }

  private void OnVideoFinished(VideoPlayer vp)
  {
    if (PlayerPrefs.GetInt("PlayingLevel1AfterTutorial", 0) == 1)
    {
      PlayerPrefs.DeleteKey("PlayingLevel1AfterTutorial");
      StartCoroutine(StartLevelWithCountdown());
    }
  }

  private IEnumerator StartLevelWithCountdown()
  {
    if (countdownText != null)
    {
      countdownText.color = Color.white;
      countdownText.gameObject.SetActive(true);

      fadedBackground.SetActive(true);
      string[] sequence = { "PREPARADO(A)?", "3", "2", "1", "JÁ!" };
      foreach (string text in sequence)
      {
        countdownText.text = text;
        yield return new WaitForSeconds(1f);
      }

      countdownText.gameObject.SetActive(false);
    }

    SceneManager.LoadScene("Gameplay_Scene");
  }
}
