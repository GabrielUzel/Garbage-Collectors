using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPopUp : MonoBehaviour
{    public void BackHome()
    {
        SceneManager.LoadScene("Main_Menu_Scene");
    }

    
public void BackButton(){
    SceneManager.LoadScene("");
}
public void StartButton(){
    SceneManager.LoadScene("");
}
}
