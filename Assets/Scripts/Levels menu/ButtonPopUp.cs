using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPopUp : MonoBehaviour
{
    public void StartButton(Text LevelText)
    {
        Debug.Log(LevelText.text);
        SceneManager.LoadScene("Level_One_Scene");
    }
}
