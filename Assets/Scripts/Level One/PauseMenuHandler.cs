using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine;

public class PauseMenuHandler : MonoBehaviour{
    public GameObject pauseMenu;
    public GameObject musicButton;
    public GameObject soundButton;
    public GameObject continueButton;
    public GameObject restartButton;
    public GameObject homeButton;

    public Sprite[] music = new Sprite[2];
    public Sprite[] soundEf = new Sprite[2];

    public bool musicIsMuted = false;
    public bool soundIsMuted = false;

    public void TogglePauseMenu(){
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        musicButton.SetActive(true);
        soundButton.SetActive(true);
        continueButton.SetActive(true);
        restartButton.SetActive(true);
        homeButton.SetActive(true);
    }

    public void ToggleMusic(){
        //TODO musica funcinar e mudar sprites do item do menu pop up
    } 

    public void ToggleSoundEffect(){
        //TODO som funcionar e mudar sprites do item do menu pop up
    }

    public void ContinueAction(){
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        musicButton.SetActive(false);
        soundButton.SetActive(false);
        continueButton.SetActive(false);
        restartButton.SetActive(false);
        homeButton.SetActive(false);
    }

    public void RestartAction(){
        SceneManager.LoadScene("Level_One_Scene");
        Time.timeScale = 1f;
    }

    public void HomeAction(){
        SceneManager.LoadScene("Main_Menu_Scene");
        Time.timeScale = 1f;
    }
}
