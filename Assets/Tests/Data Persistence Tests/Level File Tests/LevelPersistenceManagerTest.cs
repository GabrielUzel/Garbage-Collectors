using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class LevelPersistenceManagerTests
{
  private LevelPersistenceManager _manager;
  private GameObject _managerObject;
  private string _testDirectory;
  private readonly string _testFileName = "test.json";

  [SetUp]
  public void Setup()
  {
    _testDirectory = Path.Combine(Path.GetTempPath(), "DataPersistenceTest");
    Directory.CreateDirectory(_testDirectory);

    var mockLevelData = new LevelData {levelsInitialInfo = new List<LevelInfo> { new LevelInfo { levelId = 1, trashCount = 15, timeInSeconds = 120 }}};
    string json = JsonUtility.ToJson(mockLevelData);
    string encryptedJson = Encryption.Encrypt(json);
    File.WriteAllText(Path.Combine(_testDirectory, _testFileName), encryptedJson);

    _managerObject = new GameObject("LevelPersistenceManager");
    _manager = _managerObject.AddComponent<LevelPersistenceManager>();
    
    var levelHandler = new LevelDataHandler(_testDirectory, "test.json");
    _manager.GetType().GetField("levelDataHandler", BindingFlags.NonPublic | BindingFlags.Instance)
        .SetValue(_manager, levelHandler);

    var levelPersistenceObjectsField = _manager.GetType()
        .GetField("levelPersistenceObjects", BindingFlags.NonPublic | BindingFlags.Instance);
    levelPersistenceObjectsField.SetValue(_manager, new List<ILevelPersistence>());
  }

  [TearDown]
  public void Teardown()
  {
    Object.DestroyImmediate(_managerObject);
    Directory.Delete(_testDirectory, true);
  }

  [UnityTest]
  public IEnumerator LoadLevelsData_Test()
  {
    var testObject = new GameObject("TestObject");
    var dataComponent = testObject.AddComponent<MockDataPersistence>();

    var levelPersistenceObjectsField = _manager.GetType()
      .GetField("levelPersistenceObjects", BindingFlags.NonPublic | BindingFlags.Instance);
    levelPersistenceObjectsField.SetValue(_manager, new List<ILevelPersistence> { dataComponent });

    _manager.LoadLevelsData();

    Assert.AreEqual(1, dataComponent.LastLoadedData.levelsInitialInfo[0].levelId);
    Assert.AreEqual(15, dataComponent.LastLoadedData.levelsInitialInfo[0].trashCount);
    Assert.AreEqual(120, dataComponent.LastLoadedData.levelsInitialInfo[0].timeInSeconds);

    Object.DestroyImmediate(testObject);
    yield return null;
  }

  public class MockDataPersistence : MonoBehaviour, ILevelPersistence
  {
    public LevelData LastLoadedData;

    public void LoadData(LevelData data)
    {
      LastLoadedData = data;
    }
  }
}
