using UnityEngine;

public class LoadLevelsInfo : MonoBehaviour, ILevelPersistence
{
    public static LoadLevelsInfo Instance;
    public LevelData LevelData;
    private LevelInfo currentLevelInfo;
    private int levelId;
    private int totalWaste;
    private int lifes;
    private int timeInSeconds;
    private int totalLevels;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        currentLevelInfo = LevelData.levelsInitialInfo.Find(info => info.levelId == GameSessionData.LastPlayedLevel);
        levelId = currentLevelInfo.levelId;
        totalWaste = currentLevelInfo.trashCount;
        lifes = currentLevelInfo.lifes;
        timeInSeconds = currentLevelInfo.timeInSeconds;
        totalLevels = LevelData.totalLevels;
    }

    public int GetLevelId()
    {
        return levelId;
    }

    public int GetTotalWaste()
    {
        return totalWaste;
    }

    public int GetLifes()
    {
        return lifes;
    }

    public int GetTimeInSeconds()
    {
        return timeInSeconds;
    }

    public int GetTotalLevels()
    {
        return LevelData.totalLevels;
    }

    public void LoadData(LevelData levelData)
    {
        LevelData = levelData;
    }
}
