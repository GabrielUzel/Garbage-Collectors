using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeAvatarButtonHandler : MonoBehaviour
{
    public void LoadChangeAvatarScene()
    {
        SceneManager.LoadScene("Change-Avatar-Scene");
    }
}
