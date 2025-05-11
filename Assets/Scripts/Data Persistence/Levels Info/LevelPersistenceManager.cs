using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class LevelPersistenceManager : MonoBehaviour
{
    [Header("Level Storage Configuration")]
    private string fileName = "levels_data.json";

    private LevelData levelData;
    private List<ILevelPersistence> levelPersistenceObjects;
    private LevelDataHandler levelDataHandler;
    public static LevelPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.levelDataHandler = new LevelDataHandler(Path.Combine(Application.dataPath, "Data"), fileName);
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
        this.levelPersistenceObjects = FindAllLevelPersistenceObjects();
        LoadLevelsData();
    }

    public void OnSceneUnloaded(Scene scene)
    {

    }

    public void LoadLevelsData()
    {
        this.levelData = levelDataHandler.Load();

        foreach (ILevelPersistence levelPersistenceObject in levelPersistenceObjects)
        {
            levelPersistenceObject.LoadData(levelData);
        }
    }

    private List<ILevelPersistence> FindAllLevelPersistenceObjects()
    {
        IEnumerable<ILevelPersistence> levelPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<ILevelPersistence>();

        return new List<ILevelPersistence>(levelPersistenceObjects);
    }
}
