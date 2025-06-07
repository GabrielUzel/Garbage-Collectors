using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TutorialScener : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoPanel; 

    public void PlayTutorial()
    {
        videoPanel.SetActive(true);
        videoPlayer.Play();
    }

    public void StopTutorial()
    {
        videoPlayer.Stop();
        videoPanel.SetActive(false);
            SceneManager.LoadScene("Main_Menu_Scene");

    }
}
