using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public static void LoadScene(string sceneName)
  {
    LoadingManager.sceneToLoad = sceneName;
    SceneManager.LoadScene("Loading_Scene");
  }
}