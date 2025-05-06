using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButtonController : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Main_Menu_Scene");
    }
}
