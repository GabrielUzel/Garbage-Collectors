using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class AvatarTest
{
    private GameObject testObject;
    private Avatar avatar;
    private TrashCountManager trashCountManager;
    private LoadLevelsInfo loadLevelsInfo;

    [SetUp]
    public void SetUp()
    {
        PlayerPrefs.DeleteAll();
        GameSessionData.LastPlayedLevel = 1;

        foreach (var waste in GameObject.FindGameObjectsWithTag("Waste"))
        {
            Object.DestroyImmediate(waste);
        }

        LevelData mockLevelData = new LevelData
        {
            levelsInitialInfo = new List<LevelInfo>
            {
                new LevelInfo { levelId = 1, trashCount = 5, timeInSeconds = 100 }
            }
        };

        GameObject trashCountManagerGO = new GameObject("TrashCountManager");
        trashCountManager = trashCountManagerGO.AddComponent<TrashCountManager>();
        TrashCountManager.Instance = trashCountManager;

        GameObject loadLevelsInfoGO = new GameObject("LoadLevelsInfo");
        loadLevelsInfo = loadLevelsInfoGO.AddComponent<LoadLevelsInfo>();
        loadLevelsInfo.Awake();
        loadLevelsInfo.LoadData(mockLevelData);
        loadLevelsInfo.Start();

        testObject = new GameObject("Avatar");
        avatar = testObject.AddComponent<Avatar>();
        avatar.spriteRenderer = testObject.AddComponent<SpriteRenderer>();

        avatar.sprites = new Sprite[6];
        for (int i = 0; i < 6; i++)
        {
            avatar.sprites[i] = Sprite.Create(new Texture2D(1, 1), new Rect(0, 0, 1, 1), Vector2.zero);
        }
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(testObject);
        Object.DestroyImmediate(trashCountManager.gameObject);
        Object.DestroyImmediate(loadLevelsInfo.gameObject);
        LoadLevelsInfo.Instance = null;
        
        foreach (var waste in GameObject.FindGameObjectsWithTag("Waste"))
        {
            Object.DestroyImmediate(waste);
        }
    }

    [Test]
    public void VerifyIsBoyVariable_BoySelected_Test()
    {
        PlayerPrefs.SetString("selected_avatar", "boy");
        avatar.Awake();
        bool isBoy = (bool)typeof(Avatar).GetField("isBoy", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(avatar);
        Assert.IsTrue(isBoy);
    }

    [Test]
    public void VerifyIsBoyVariable_GirlSelected_Test()
    {
        PlayerPrefs.SetString("selected_avatar", "girl");
        avatar.Awake();
        bool isBoy = (bool)typeof(Avatar).GetField("isBoy", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(avatar);
        Assert.IsFalse(isBoy);
    }

    [Test]
    public void VerifyCorrectSprite_InitialValue_BoySelected_Test()
    {
        PlayerPrefs.SetString("selected_avatar", "boy");
        avatar.Awake();
        avatar.Start();
        Assert.AreEqual(avatar.sprites[0], avatar.spriteRenderer.sprite);
    }

    [Test]
    public void VerifyCorrectSprite_InitialValue_GirlSelected_Test()
    {
        PlayerPrefs.SetString("selected_avatar", "girl");
        avatar.Awake();
        avatar.Start();
        Assert.AreEqual(avatar.sprites[3], avatar.spriteRenderer.sprite);
    }

    [Test]
    public void VerifyCorrectSprite_60Percentage_BoySelected_Test()
    {
        for (int i = 0; i < 5; i++)
        {
            new GameObject("Waste").tag = "Waste";
        }
        avatar.Start();

        PlayerPrefs.SetString("selected_avatar", "boy");
        avatar.Awake();
        avatar.Start();

        trashCountManager.CorrectTrashCount = 3;
        avatar.Update();

        Assert.AreEqual(avatar.sprites[1], avatar.spriteRenderer.sprite);
    }

    [Test]
    public void VerifyCorrectSprite_60Percentage_GirlSelected_Test()
    {
        for (int i = 0; i < 5; i++)
        {
            new GameObject("Waste").tag = "Waste";
        }
        avatar.Start();

        PlayerPrefs.SetString("selected_avatar", "girl");
        avatar.Awake();
        avatar.Start();

        trashCountManager.CorrectTrashCount = 3;
        avatar.Update();

        Assert.AreEqual(avatar.sprites[4], avatar.spriteRenderer.sprite);
    }

    [Test]
    public void VerifyCorrectSprite_100Percentage_BoySelected_Test()
    {
        for (int i = 0; i < 5; i++)
        {
            new GameObject("Waste").tag = "Waste";
        }
        avatar.Start();

        PlayerPrefs.SetString("selected_avatar", "boy");
        avatar.Awake();
        avatar.Start();

        trashCountManager.CorrectTrashCount = 5;
        avatar.Update();

        Assert.AreEqual(avatar.sprites[2], avatar.spriteRenderer.sprite);
    }

    [Test]
    public void VerifyCorrectSprite_100Percentage_GirlSelected_Test()
    {
        for (int i = 0; i < 5; i++)
        {
            new GameObject("Waste").tag = "Waste";
        }
        avatar.Start();

        PlayerPrefs.SetString("selected_avatar", "girl");
        avatar.Awake();
        avatar.Start();

        trashCountManager.CorrectTrashCount = 5;
        avatar.Update();

        Assert.AreEqual(avatar.sprites[5], avatar.spriteRenderer.sprite);
    }
}
