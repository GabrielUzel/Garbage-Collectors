using UnityEngine;
using UnityEngine.Video;

public class TutorialScener : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoPanel; // O RawImage ou um pai com CanvasGroup

    public void PlayTutorial()
    {
        videoPanel.SetActive(true);
        videoPlayer.Play();
    }

    public void StopTutorial()
    {
        videoPlayer.Stop();
        videoPanel.SetActive(false);
    }
}
