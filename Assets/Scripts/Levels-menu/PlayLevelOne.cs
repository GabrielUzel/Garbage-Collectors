using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevelOne : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene("Main_Menu_Scene");
    }
}