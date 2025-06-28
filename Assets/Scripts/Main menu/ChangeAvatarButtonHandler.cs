using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeAvatarButtonHandler : MonoBehaviour
{
  public void LoadChangeAvatarScene()
  {
    SceneManager.LoadScene("Change_Avatar_Scene");
  }
}
