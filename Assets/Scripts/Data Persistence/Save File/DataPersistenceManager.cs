using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Configuration")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistence> DataPersistenceObjects;
    private FileDataHandler fileDataHandler;
    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += onSceneLoaded;
        SceneManager.sceneUnloaded += onSceneUnloaded;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= onSceneLoaded;
        SceneManager.sceneUnloaded -= onSceneUnloaded;
    }

    public void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.DataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void onSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = fileDataHandler.Load();

        if (gameData == null)
        {
            Debug.Log("No game data found. Please start a new game.");
            NewGame();
            SaveGame();
        }

        foreach (IDataPersistence dataPersistenceObject in DataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObject in DataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(ref gameData);
        }

        fileDataHandler.Save(gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
