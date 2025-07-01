using UnityEngine;
using System.Collections.Generic;

public class GameProgressSaver : MonoBehaviour, IDataPersistence
{
  public static GameProgressSaver Instance;
  private GameData gameData;
  private int PlayerCurrentLevel;
  private List<LevelInfoInPhases> LevelInfosPhase;
  private int totalLevels;
  private int totalHits = 0;
  private int totalErrors = 0;
  private readonly HashSet<int> levelsAlreadyUpdated = new HashSet<int>();

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
    PlayerCurrentLevel = gameData.PlayerCurrentLevel;
    LevelInfosPhase = gameData.LevelInfosPhase;
    totalLevels = LoadLevelsInfo.Instance.GetTotalLevels();
    totalHits = gameData.TotalHits;
    totalErrors = gameData.TotalErrors;
    levelsAlreadyUpdated.Clear();
  }

  public void UpdateSaveFile(int levelId, int lastPlayedLevel, int newBestTime, int newHighScore, int hits, int errors, bool userWon)
  {
    if (PlayerCurrentLevel <= lastPlayedLevel && PlayerCurrentLevel < totalLevels && userWon)
    {
      PlayerCurrentLevel = lastPlayedLevel + 1;
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

    if (!levelsAlreadyUpdated.Contains(levelId))
    {
      totalHits += hits;
      totalErrors += errors;
      levelsAlreadyUpdated.Add(levelId);
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
    gameData.TotalHits = totalHits;
    gameData.TotalErrors = totalErrors;
  }
}
