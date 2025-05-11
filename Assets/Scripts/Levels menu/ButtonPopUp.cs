using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPopUp : MonoBehaviour
{
    public void StartButton(Text LevelText)
    {
        switch (LevelText.text)
        {
            case "1":
                SceneManager.LoadScene("Level_One_Scene");
                break;
            case "Level 2":
                SceneManager.LoadScene("Level_Two_Scene");
                break;
            case "Level 3":
                SceneManager.LoadScene("Level_Three_Scene");
                break;
            case "Level 4":
                SceneManager.LoadScene("Level_Four_Scene");
                break;
            case "Level 5":
                SceneManager.LoadScene("Level_Five_Scene");
                break;
        }
    }
}
