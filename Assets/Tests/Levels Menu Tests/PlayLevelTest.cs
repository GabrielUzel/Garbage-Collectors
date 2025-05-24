using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;

public class PlayLevelTests
{
    private GameObject playLevelObject;
    private PlayLevel playLevel;
    private GameObject popUpPanel;
    private GameObject levelButtonsGroup;
    private Button returnToHomeButton;
    private Image background;

    [SetUp]
    public void Setup()
    {
        playLevelObject = new GameObject("PlayLevel");
        playLevel = playLevelObject.AddComponent<PlayLevel>();

        popUpPanel = new GameObject("PopUpPanel");
        levelButtonsGroup = new GameObject("LevelButtonsGroup");
        returnToHomeButton = new GameObject("ReturnToHomeButton").AddComponent<Button>();
        background = new GameObject("Background").AddComponent<Image>();

        playLevel.PopUpPanel = popUpPanel;
        playLevel.LevelButtonsGroup = levelButtonsGroup;
        playLevel.ReturnToHomeButton = returnToHomeButton;
        playLevel.Background = background;
        
        var mockLevelData = new LevelData
        {
            levelsInitialInfo = new List<LevelInfo>
            {
                new() { levelId = 1, trashCount = 10, timeInSeconds = 100 },
                new() { levelId = 2, trashCount = 20, timeInSeconds = 200 }
            }
        };

        playLevel.LoadData(mockLevelData);

        GameObject infoPanelObject = new GameObject("InfoPanel");
        InfoPanel mockInfoPanel = infoPanelObject.AddComponent<InfoPanel>();

        mockInfoPanel.LevelText = new GameObject("LevelText").AddComponent<Text>();
        mockInfoPanel.TrashText = new GameObject("TrashText").AddComponent<Text>();
        mockInfoPanel.TimeText = new GameObject("TimeText").AddComponent<Text>();

        InfoPanel.Instance = mockInfoPanel;
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(playLevelObject);
    }

    [UnityTest]
    public IEnumerator LoadPopUp_Test()
    {
        var testButton = new GameObject("LevelOne").AddComponent<Button>();
        testButton.transform.SetParent(levelButtonsGroup.transform);

        playLevel.LoadPopUp(testButton);

        Assert.IsTrue(popUpPanel.activeSelf);
        Assert.IsFalse(returnToHomeButton.interactable);
        Assert.AreEqual(new Color(255, 255, 255, 0.5f), background.color);

        yield return null;
    }

    [UnityTest]
    public IEnumerator OnClickLevelButton_Button1_Test()
    {
        var testButton = new GameObject("LevelOne").AddComponent<Button>();
        testButton.transform.SetParent(levelButtonsGroup.transform);

        playLevel.OnClickLevelButton(testButton);

        Assert.AreEqual(1, playLevel.GetLevelId());
        Assert.AreEqual(10, playLevel.GetTrashCount());
        Assert.AreEqual(100, playLevel.GetTimeInSeconds());

        yield return null;
    }

        [UnityTest]
    public IEnumerator OnClickLevelButton_Button2_Test()
    {
        var testButton = new GameObject("LevelTwo").AddComponent<Button>();
        testButton.transform.SetParent(levelButtonsGroup.transform);

        playLevel.OnClickLevelButton(testButton);

        Assert.AreEqual(2, playLevel.GetLevelId());
        Assert.AreEqual(20, playLevel.GetTrashCount());
        Assert.AreEqual(200, playLevel.GetTimeInSeconds());

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestClosePopUp()
    {
        var testButton = new GameObject("LevelOne").AddComponent<Button>();
        testButton.name = "LevelOne"; 
        testButton.transform.SetParent(levelButtonsGroup.transform);

        playLevel.LoadPopUp(testButton);
        playLevel.ClosePopUp();

        Assert.IsFalse(popUpPanel.activeSelf);
        Assert.IsTrue(returnToHomeButton.interactable);
        Assert.AreEqual(new Color(255, 255, 255, 1), background.color);

        yield return null;
    }
}

