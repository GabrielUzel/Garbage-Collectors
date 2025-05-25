using UnityEngine;
using System.Collections.Generic;

public class GameProgressSaver : MonoBehaviour, IDataPersistence, ILevelPersistence
{
    public static GameProgressSaver Instance;
    private GameData gameData;
    private int PlayerCurrentLevel;
    private List<LevelInfoInPhases> LevelInfosPhase;
    private LevelData levelData;
    private int totalLevels;

    void Awake()
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

    void Start()
    {
        PlayerCurrentLevel = gameData.PlayerCurrentLevel;
        LevelInfosPhase = gameData.LevelInfosPhase;
        totalLevels = levelData.totalLevels;
    }

    public void UpdateSaveFile(int levelId, int newPlayerCurrentLevel, int newBestTime, int newHighScore)
    {
        if (PlayerCurrentLevel <= newPlayerCurrentLevel && PlayerCurrentLevel <= totalLevels)
        {
            PlayerCurrentLevel = newPlayerCurrentLevel;
        }

        var levelInfo = LevelInfosPhase.Find(l => l.id == levelId);
        if (newBestTime < levelInfo.best_time)
        {
            levelInfo.best_time = newBestTime;
        }

        if (newHighScore > levelInfo.highscore)
        {
            levelInfo.highscore = newHighScore;
        }
        
        SaveData(ref gameData);
    }

    public void LoadData(GameData gameData)
    {
        this.gameData = gameData;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.PlayerCurrentLevel = PlayerCurrentLevel;
        gameData.LevelInfosPhase = LevelInfosPhase;
    }
    
    public void LoadData(LevelData levelData)
    {
        this.levelData = levelData;
    }
}
