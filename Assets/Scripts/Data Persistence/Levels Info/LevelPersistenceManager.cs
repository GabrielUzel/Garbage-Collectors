using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class LevelPersistenceManager : MonoBehaviour
{
  [Header("Level Storage Configuration")]
  private string fileName = "levels_data.enc";

  private LevelData levelData;
  private List<ILevelPersistence> levelPersistenceObjects;
  private LevelDataHandler levelDataHandler;
  public static LevelPersistenceManager Instance { get; private set; }

  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
    levelDataHandler = new LevelDataHandler(Application.streamingAssetsPath, fileName);
  }

  public void OnEnable()
  {
    SceneManager.sceneLoaded += OnSceneLoaded;
    SceneManager.sceneUnloaded += OnSceneUnloaded;
  }

  public void OnDisable()
  {
    SceneManager.sceneLoaded -= OnSceneLoaded;
    SceneManager.sceneUnloaded -= OnSceneUnloaded;
  }

  public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
    levelPersistenceObjects = FindAllLevelPersistenceObjects();
    LoadLevelsData();
  }

  public void OnSceneUnloaded(Scene scene)
  {
    // Empty implementation
  }

  public void LoadLevelsData()
  {
    levelData = levelDataHandler.Load();

    foreach (ILevelPersistence levelPersistenceObject in levelPersistenceObjects)
    {
      levelPersistenceObject.LoadData(levelData);
    }
  }

  private List<ILevelPersistence> FindAllLevelPersistenceObjects()
  {
    IEnumerable<ILevelPersistence> levelPersistenceObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
      .OfType<ILevelPersistence>();

    return new List<ILevelPersistence>(levelPersistenceObjects);
  }
}
