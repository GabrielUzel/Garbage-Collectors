using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
  public static string sceneToLoad;

  public Slider progressBar; 

  void Start()
  {
    StartCoroutine(LoadSceneAsync());
  }

  IEnumerator LoadSceneAsync()
  {
    yield return null;

    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
    asyncOperation.allowSceneActivation = false;

    while (!asyncOperation.isDone)
    {
      float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

      if (progressBar != null)
      {
        progressBar.value = progress;
      }

      if (asyncOperation.progress >= 0.9f)
      {
        yield return new WaitForSeconds(1);
        asyncOperation.allowSceneActivation = true;
      }

      yield return null;
    }
  }
}
