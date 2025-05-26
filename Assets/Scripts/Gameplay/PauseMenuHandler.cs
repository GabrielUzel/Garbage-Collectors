using UnityEngine;
using UnityEngine.UI;

public class PauseMenuHandler : MonoBehaviour
{
    public AudioSource musicSource;
    public GameObject pauseMenu;
    public GameObject musicButton;
    public GameObject soundButton;
    public GameObject continueButton;
    public GameObject restartButton;
    public GameObject homeButton;
    public GameObject fadedBackground;

    public Sprite[] music = new Sprite[2];
    public Sprite[] soundEf = new Sprite[2];

    public bool musicIsMuted = false;
    public bool soundIsMuted = false;

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

    public void ToggleMusic()
    {
        if (musicIsMuted)
        {
            musicButton.GetComponents<Image>()[0].sprite = music[0];
            musicIsMuted = !musicIsMuted;
        }
        else
        {
            musicButton.GetComponents<Image>()[0].sprite = music[1];
            musicIsMuted = !musicIsMuted;
        }
           
        musicSource.mute = musicIsMuted;
    }

    public void ToggleSoundEffect()
    {
        if (soundIsMuted)
        {
            soundButton.GetComponents<Image>()[0].sprite = soundEf[0];
            soundIsMuted = !soundIsMuted;
        }
        else
        {
            soundButton.GetComponents<Image>()[0].sprite = soundEf[1];
            soundIsMuted = !soundIsMuted;
        }

        // TODO: Toggle sound effects
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
    }
}
