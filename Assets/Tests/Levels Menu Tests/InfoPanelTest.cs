using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[TestFixture]
public class InfoPanelTests
{
  [SetUp]
  public void SetUp()
  {
    InfoPanel.Instance = null;
  }

  [Test]
  public void UpdatePanel_Test()
  {
    var infoPanelObject = new GameObject();
    var infoPanel = infoPanelObject.AddComponent<InfoPanel>();

    infoPanel.LevelText = new GameObject("LevelText").AddComponent<Text>();
    infoPanel.TrashText = new GameObject("TrashText").AddComponent<Text>();
    infoPanel.TimeText = new GameObject("TimeText").AddComponent<Text>();

    int levelId = 1;
    int trashCount = 15;
    int timeInSeconds = 120;

    infoPanel.UpdatePanel(levelId, trashCount, timeInSeconds);

    Assert.AreEqual(levelId.ToString(), infoPanel.LevelText.text);
    Assert.AreEqual(trashCount.ToString(), infoPanel.TrashText.text);
    Assert.AreEqual("2:00", infoPanel.TimeText.text);
  }

  [TestCase(0, "0:00")]
  [TestCase(59, "0:59")]
  [TestCase(60, "1:00")]
  [TestCase(119, "1:59")]
  [TestCase(120, "2:00")]
  public void UpdatePanel_VerifyTimeFormat_Test(int timeInSeconds, string expectedTime)
  {
    var infoPanelObject = new GameObject();
    var infoPanel = infoPanelObject.AddComponent<InfoPanel>();

    infoPanel.LevelText = new GameObject("LevelText").AddComponent<Text>();
    infoPanel.TrashText = new GameObject("TrashText").AddComponent<Text>();
    infoPanel.TimeText = new GameObject("TimeText").AddComponent<Text>();

    infoPanel.UpdatePanel(1, 1, timeInSeconds);

    Assert.AreEqual(expectedTime, infoPanel.TimeText.text);
  }

  [Test]
  public void Awake_Test()
  {
    var infoPanelObject = new GameObject();
    var infoPanel = infoPanelObject.AddComponent<InfoPanel>();

    infoPanel.Awake();

    Assert.IsNotNull(InfoPanel.Instance);
  }
}