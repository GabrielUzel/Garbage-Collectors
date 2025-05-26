using NUnit.Framework;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

[TestFixture]
public class LevelDataHandlerTests
{
    private string _testDirectory;
    private readonly string _testFileName = "testLevelData.json";
    private LevelDataHandler _levelDataHandler;

    [SetUp]
    public void Setup()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(_testDirectory);
        _levelDataHandler = new LevelDataHandler(_testDirectory, _testFileName);
    }

    [TearDown]
    public void TearDown()
    {
        Directory.Delete(_testDirectory, true);
    }

    [Test]
    public void LoadLevelData_Test()
    {
        LevelData testData = new LevelData {levelsInitialInfo = new List<LevelInfo> {new LevelInfo { levelId = 1, trashCount = 15, timeInSeconds = 120 }}}; 

        string fullPath = Path.Combine(_testDirectory, _testFileName);
        File.WriteAllText(fullPath, JsonUtility.ToJson(testData));

        LevelData loadedData = _levelDataHandler.Load();

        Assert.IsNotNull(loadedData);
        Assert.AreEqual(1, loadedData.levelsInitialInfo[0].levelId);
        Assert.AreEqual(15, loadedData.levelsInitialInfo[0].trashCount);
        Assert.AreEqual(120, loadedData.levelsInitialInfo[0].timeInSeconds);
    }

    [Test]
    public void LoadLevelData_WrongValues_Test()
    {
        LevelData testData = new LevelData {levelsInitialInfo = new List<LevelInfo> {new LevelInfo { levelId = 2, trashCount = 25, timeInSeconds = 170 }}}; 

        string fullPath = Path.Combine(_testDirectory, _testFileName);
        File.WriteAllText(fullPath, JsonUtility.ToJson(testData));

        LevelData loadedData = _levelDataHandler.Load();

        Assert.IsNotNull(loadedData);
        Assert.AreNotEqual(1, loadedData.levelsInitialInfo[0].levelId);
        Assert.AreNotEqual(15, loadedData.levelsInitialInfo[0].trashCount);
        Assert.AreNotEqual(120, loadedData.levelsInitialInfo[0].timeInSeconds);
    }
}
