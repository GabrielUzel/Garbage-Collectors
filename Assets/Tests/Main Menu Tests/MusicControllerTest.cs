using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

public class MusicControllerTests 
{
    private GameObject gameObject;
    private MusicController musicController;
    private Button testButton;
    private Sprite spriteOn;
    private Sprite spriteOff;

    [SetUp]
    public void SetUp() 
    {
        gameObject = new GameObject();
        musicController = gameObject.AddComponent<MusicController>();

        GameObject buttonObject = new GameObject();
        testButton = buttonObject.AddComponent<Button>();
        testButton.image = buttonObject.AddComponent<Image>();

        spriteOn = Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 1, 1), Vector2.zero);
        spriteOff = Sprite.Create(Texture2D.blackTexture, new Rect(0, 0, 1, 1), Vector2.zero);

        musicController.musicButton = testButton;
        musicController.musicOn = spriteOn;
        musicController.musicOff = spriteOff;
    }

    [TearDown]
    public void TearDown() 
    {
        UnityEngine.Object.DestroyImmediate(gameObject);
    }

    [Test]
    public void ToggleMusic_UnmutedToMuted_Test() 
    {
        musicController.toggleMusic();

        Assert.AreEqual(spriteOff, testButton.image.sprite);
    }

    [Test]
    public void ToggleMusic_mutedToUnmuted_Test() 
    {
        musicController.toggleMusic();
        musicController.toggleMusic();

        Assert.AreEqual(spriteOn, testButton.image.sprite);
    }
}
