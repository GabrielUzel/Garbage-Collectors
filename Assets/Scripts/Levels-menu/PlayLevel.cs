using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevel : MonoBehaviour
{
    public void LoadLevelPopUp()
    {
        SceneManager.LoadScene("PopUp");
    }
}