using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< HEAD:Assets/Tests/MusicControllerTest.cs
public class MusicControllerTests
=======
public class MusicControllerTests 
>>>>>>> main:Assets/Tests/Main Menu Tests/MusicControllerTest.cs
{
    private GameObject gameObject;
    private MusicController musicController;
    private Button testButton;
    private Sprite spriteOn;
    private Sprite spriteOff;

    private const string musicPrefKey = "MusicMuted";

    [SetUp]
    public void SetUp()
    {
        
        PlayerPrefs.DeleteKey(musicPrefKey);

       
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

       
        musicController.musicSource = gameObject.AddComponent<AudioSource>();
    }

    [TearDown]
    public void TearDown()
    {
        UnityEngine.Object.DestroyImmediate(gameObject);
    }

    [Test]
    public void ToggleMusic_UnmutedToMuted_UpdatesSpriteAndSavesPreference()
    {
        musicController.toggleMusic();

        Assert.AreEqual(spriteOff, testButton.image.sprite);
        Assert.AreEqual(1, PlayerPrefs.GetInt(musicPrefKey));
        Assert.IsTrue(musicController.musicSource.mute);
    }

    [Test]
    public void ToggleMusic_MutedToUnmuted_UpdatesSpriteAndSavesPreference()
    {
        musicController.toggleMusic(); 
        musicController.toggleMusic(); 

        Assert.AreEqual(spriteOn, testButton.image.sprite);
        Assert.AreEqual(0, PlayerPrefs.GetInt(musicPrefKey));
        Assert.IsFalse(musicController.musicSource.mute);
    }

    [Test]
    public void GetMusicState_LoadsMutedStateFromPlayerPrefs()
    {
        
        PlayerPrefs.SetInt(musicPrefKey, 1);

        musicController.getMusicState();

        Assert.AreEqual(spriteOff, testButton.image.sprite);
        Assert.IsTrue(musicController.musicSource.mute);
    }

    [Test]
    public void GetMusicState_LoadsUnmutedStateFromPlayerPrefs()
    {
        
        PlayerPrefs.SetInt(musicPrefKey, 0);

        musicController.getMusicState();

        Assert.AreEqual(spriteOn, testButton.image.sprite);
        Assert.IsFalse(musicController.musicSource.mute);
    }
}
