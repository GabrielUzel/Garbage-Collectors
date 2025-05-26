using NUnit.Framework;
using UnityEngine;
using System.IO;

[TestFixture]
public class FileDataHandlerTests
{
    private string _testDirectory;
    private readonly string _testFileName = "testSave.json";
    private FileDataHandler _fileDataHandler;

    [SetUp]
    public void Setup()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(_testDirectory);
        _fileDataHandler = new FileDataHandler(_testDirectory, _testFileName);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, true);
        }
    }

    [Test]
    public void LoadFile_Test()
    {
        GameData testData = new GameData { PlayerCurrentLevel = 1 };

        _fileDataHandler.Save(testData);
        string fullPath = Path.Combine(_testDirectory, _testFileName);

        Assert.IsTrue(File.Exists(fullPath), "Arquivo não foi criado.");

        string jsonContent = File.ReadAllText(fullPath);
        GameData loadedData = JsonUtility.FromJson<GameData>(jsonContent);
        Assert.AreEqual(1, loadedData.PlayerCurrentLevel);
    }

    [Test]
    public void CreatesANewFile_Test()
    {
        string nonExistentDirectory = Path.Combine(_testDirectory, "nonExistent");
        var handler = new FileDataHandler(nonExistentDirectory, _testFileName);
        GameData testData = new GameData();

        handler.Save(testData);
        string fullPath = Path.Combine(nonExistentDirectory, _testFileName);

        Assert.IsTrue(Directory.Exists(nonExistentDirectory), "Diretório não foi criado.");
        Assert.IsTrue(File.Exists(fullPath), "Arquivo não foi criado.");
    }
}