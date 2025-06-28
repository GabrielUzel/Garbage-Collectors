using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

public class GameProgessSaverTests
{
  private GameObject saverObject;
  private GameProgressSaver saver;
  private GameData gameData;
  private LevelInfoInPhases levelInfo;

  [SetUp]
  public void Setup()
  {
    saverObject = new GameObject();
    saver = saverObject.AddComponent<GameProgressSaver>();

    levelInfo = new LevelInfoInPhases
    {
      id = 1,
      best_time = 100,
      highscore = 200
    };

    gameData = new GameData
    {
      PlayerCurrentLevel = 1,
      LevelInfosPhase = new List<LevelInfoInPhases> { levelInfo },
      TotalHits = 5,
      TotalErrors = 2
    };

    var loadLevelsInfoObject = new GameObject();
    var loadLevelsInfo = loadLevelsInfoObject.AddComponent<LoadLevelsInfo>();

    loadLevelsInfo.LevelData = new LevelData
    {
      totalLevels = 5
    };
    typeof(LoadLevelsInfo)
      .GetField("totalLevels", BindingFlags.NonPublic | BindingFlags.Instance)
      .SetValue(loadLevelsInfo, 5);

    LoadLevelsInfo.Instance = loadLevelsInfo;

    saver.LoadData(gameData);
    saver.Start();
  }

  [TearDown]
  public void Teardown()
  {
    Object.DestroyImmediate(saverObject);
  }

  [Test]
  public void UpdateSaveFile_PlayerWins_Test()
  {
    saver.UpdateSaveFile(1, 1, 90, 250, 3, 2, true);
    Assert.AreEqual(2, gameData.PlayerCurrentLevel);
  }

  [Test]
  public void UpdateSaveFile_PlayerLost_Test()
  {
    saver.UpdateSaveFile(1, 1, 90, 250, 3, 2, false);
    Assert.AreEqual(1, gameData.PlayerCurrentLevel);
  }

  [Test]
  public void UpdateSaveFile_BestTimeIsUpdated_Test()
  {
    saver.UpdateSaveFile(1, 1, 50, 100, 0, 0, false);
    Assert.AreEqual(50, levelInfo.best_time);
  }

  [Test]
  public void UpdateSaveFile_HighscoreIsUpdated_Test()
  {
    saver.UpdateSaveFile(1, 1, 100, 300, 0, 0, false);
    Assert.AreEqual(300, levelInfo.highscore);
  }
}
