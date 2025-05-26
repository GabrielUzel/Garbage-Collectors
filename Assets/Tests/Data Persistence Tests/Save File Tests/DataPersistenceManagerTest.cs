using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class DataPersistenceManagerTests
{
    private DataPersistenceManager _manager;
    private GameObject _managerObject;
    private string _testDirectory;

    [SetUp]
    public void Setup()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), "DataPersistenceTest");
        Directory.CreateDirectory(_testDirectory);

        _managerObject = new GameObject("DataPersistenceManager");
        _manager = _managerObject.AddComponent<DataPersistenceManager>();
        
        var fileHandler = new FileDataHandler(_testDirectory, "test.json");
        _manager.GetType().GetField("fileDataHandler", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(_manager, fileHandler);

        var dataPersistenceObjectsField = _manager.GetType()
            .GetField("dataPersistenceObjects", BindingFlags.NonPublic | BindingFlags.Instance);

        dataPersistenceObjectsField.SetValue(_manager, new List<IDataPersistence>());
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(_managerObject);
        Directory.Delete(_testDirectory, true);
    }

    [Test]
    public void LoadGame_CreatesNewGame_Test()
    {
        _manager.LoadGame();

        var gameData = _manager.GetType()
            .GetField("gameData", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(_manager) as GameData;

        Assert.IsNotNull(gameData);
        Assert.AreEqual(1, gameData.PlayerCurrentLevel);
    }

    [UnityTest]
    public IEnumerator LoadGame_RightPlayerLevel_Test()
    {
        var testObject = new GameObject("TestObject");
        var dataComponent = testObject.AddComponent<MockDataPersistence>();

        var dataPersistenceObjectsField = _manager.GetType()
            .GetField("dataPersistenceObjects", BindingFlags.NonPublic | BindingFlags.Instance);
        dataPersistenceObjectsField.SetValue(_manager, new List<IDataPersistence> { dataComponent });

        var fileHandler = new FileDataHandler(_testDirectory, "test.json");
        var gameData = new GameData { PlayerCurrentLevel = 3 };
        fileHandler.Save(gameData);

        _manager.LoadGame();

        Assert.AreNotEqual(4, dataComponent.LastLoadedData.PlayerCurrentLevel);

        Object.DestroyImmediate(testObject);
        yield return null;
    }

    [UnityTest]
    public IEnumerator LoadGame_WrongPlayerLevel_Test()
    {
        var testObject = new GameObject("TestObject");
        var dataComponent = testObject.AddComponent<MockDataPersistence>();

        var dataPersistenceObjectsField = _manager.GetType()
            .GetField("dataPersistenceObjects", BindingFlags.NonPublic | BindingFlags.Instance);
        dataPersistenceObjectsField.SetValue(_manager, new List<IDataPersistence> { dataComponent });

        var fileHandler = new FileDataHandler(_testDirectory, "test.json");
        var gameData = new GameData { PlayerCurrentLevel = 1 };
        fileHandler.Save(gameData);

        _manager.LoadGame();

        Assert.AreNotEqual(4, dataComponent.LastLoadedData.PlayerCurrentLevel);

        Object.DestroyImmediate(testObject);
        yield return null;
    }

    public class MockDataPersistence : MonoBehaviour, IDataPersistence
    {
        public GameData LastLoadedData;

        public void LoadData(GameData data)
        {
            LastLoadedData = data;
        }

        public void SaveData(ref GameData data)
        {
            data.PlayerCurrentLevel = 1;
        }
    }
}
