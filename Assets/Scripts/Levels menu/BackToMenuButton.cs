using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour
{
    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu_Scene");
    }
}