using UnityEngine;
using UnityEngine.UI;

public class PauseMenuHandler : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject musicButton;
    public GameObject soundButton;
    public GameObject continueButton;
    public GameObject restartButton;
    public GameObject homeButton;
    public GameObject fadedBackground;

    public Sprite[] music = new Sprite[2];
    public Sprite[] soundEf = new Sprite[2];

    public void TogglePauseMenu()
    {
        TimeManager.Instance.timerIsRunning = false;
        fadedBackground.SetActive(true);
        pauseMenu.SetActive(true);
        musicButton.SetActive(true);
        soundButton.SetActive(true);
        continueButton.SetActive(true);
        restartButton.SetActive(true);
        homeButton.SetActive(true);
    }

    public void ContinueAction()
    {
        TimeManager.Instance.timerIsRunning = true;
        fadedBackground.SetActive(false);
        pauseMenu.SetActive(false);
        musicButton.SetActive(false);
        soundButton.SetActive(false);
        continueButton.SetActive(false);
        restartButton.SetActive(false);
        homeButton.SetActive(false);

        Texture2D mouseCursor = Resources.Load<Texture2D>("cursor_mouse");
        if (mouseCursor != null)
        {
            Cursor.SetCursor(mouseCursor, new Vector2(5, 5), CursorMode.Auto);
        }
    }
}
