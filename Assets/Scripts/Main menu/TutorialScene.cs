using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TutorialScener : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoPanel;

    public void PlayTutorial()
    {
        PlayerPrefs.DeleteKey("PlayingLevel1AfterTutorial");
        SceneManager.LoadScene("Tutorial_Scene");
    }
}
