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
    }
}
