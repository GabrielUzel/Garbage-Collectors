using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class AvatarTest
{
    private GameObject testObject;
    private Avatar avatar;

    private ScoreManager scoreManager;
    [SetUp]
    public void SetUp()
    {
        PlayerPrefs.DeleteAll();

        foreach (var waste in GameObject.FindGameObjectsWithTag("Waste"))
        {
            Object.DestroyImmediate(waste);
        }

        GameObject scoreManagerGO = new GameObject("ScoreManager");
        scoreManager = scoreManagerGO.AddComponent<ScoreManager>();
        ScoreManager.Instance = scoreManager;
        scoreManager.score = 0;

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
        Object.DestroyImmediate(scoreManager.gameObject);
        foreach (var waste in GameObject.FindGameObjectsWithTag("Waste"))
        {
            Object.DestroyImmediate(waste);
        }
    }

    [Test]
    public void VerifyISBoyVariable_BoySelected_Test()
    {
        PlayerPrefs.SetString("selected_avatar", "boy");
        avatar.Awake();
        bool isBoy = (bool)typeof(Avatar).GetField("isBoy", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(avatar);
        Assert.IsTrue(isBoy);
    }

    [Test]
    public void VerifyISBoyVariable_GirlSelected_Test()
    {
        PlayerPrefs.SetString("selected_avatar", "girl");
        avatar.Awake();
        bool isBoy = (bool)typeof(Avatar).GetField("isBoy", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(avatar);
        Assert.IsFalse(isBoy);
    }

    [Test]
    public void VerifyScoreValue_3WastesEqualsTo600_Test()
    {
        for (int i = 0; i < 3; i++)
        {
            new GameObject("Waste").tag = "Waste";
        }

        avatar.Start();
        int totalScore = (int)typeof(Avatar).GetField("totalScore", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(avatar);
        Assert.AreEqual(600, totalScore);
    }

    [Test]
    public void VerifyScoreValue_5WastesEqualsTo1000_Test()
    {
        for (int i = 0; i < 5; i++)
        {
            new GameObject("Waste").tag = "Waste";
        }

        avatar.Start();
        int totalScore = (int)typeof(Avatar).GetField("totalScore", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(avatar);
        Assert.AreEqual(1000, totalScore);
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
    public void VerifyCorrectSprite_40Percentage_BoySelected_Test()
    {
        for (int i = 0; i < 5; i++)
        {
            new GameObject("Waste").tag = "Waste";
        }
        avatar.Start();

        PlayerPrefs.SetString("selected_avatar", "boy");
        avatar.Awake();
        avatar.Start();

        scoreManager.score = 400;
        avatar.Update();

        Assert.AreEqual(avatar.sprites[1], avatar.spriteRenderer.sprite);
    }

    [Test]
    public void VerifyCorrectSprite_40Percentage_GirlSelected_Test()
    {
        for (int i = 0; i < 5; i++)
        {
            new GameObject("Waste").tag = "Waste";
        }
        avatar.Start();

        PlayerPrefs.SetString("selected_avatar", "girl");
        avatar.Awake();
        avatar.Start();

        scoreManager.score = 400;
        avatar.Update();

        Assert.AreEqual(avatar.sprites[4], avatar.spriteRenderer.sprite);
    }

    [Test]
    public void VerifyCorrectSprite_70Percentage_BoySelected_Test()
    {
        for (int i = 0; i < 5; i++)
        {
            new GameObject("Waste").tag = "Waste";
        }
        avatar.Start();

        PlayerPrefs.SetString("selected_avatar", "boy");
        avatar.Awake();
        avatar.Start();

        scoreManager.score = 700;
        avatar.Update();

        Assert.AreEqual(avatar.sprites[2], avatar.spriteRenderer.sprite);
    }

    [Test]
    public void VerifyCorrectSprite_70Percentage_GirlSelected_Test()
    {
        for (int i = 0; i < 5; i++)
        {
            new GameObject("Waste").tag = "Waste";
        }
        avatar.Start();

        PlayerPrefs.SetString("selected_avatar", "girl");
        avatar.Awake();
        avatar.Start();

        scoreManager.score = 700;
        avatar.Update();

        Assert.AreEqual(avatar.sprites[5], avatar.spriteRenderer.sprite);
    }
}
