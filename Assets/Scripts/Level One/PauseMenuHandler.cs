using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
    public GameObject pauseMenu;

    public void TogglePauseMenu()
    {
        // Ativa ou desativa o menu
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
