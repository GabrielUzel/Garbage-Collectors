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

        Texture2D mouseCursor = Resources.Load<Texture2D>("cursor_mouse");
        if (mouseCursor != null)
        {
            Cursor.SetCursor(mouseCursor, new Vector2(5, 5), CursorMode.Auto);
        }
    }
}
