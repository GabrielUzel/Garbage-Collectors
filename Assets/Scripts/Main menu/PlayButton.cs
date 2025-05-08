using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadChangeLevelOneScene()
    {
        SceneManager.LoadScene("Level_One_Scene");
    }
}
