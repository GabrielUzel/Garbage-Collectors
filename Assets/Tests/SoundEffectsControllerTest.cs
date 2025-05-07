using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

public class SoundEffectsControllerTests {
    private GameObject gameObject;
    private SoundEffectsController SoundEffectsController;
    private Button testButton;
    private Sprite spriteOn;
    private Sprite spriteOff;

    [SetUp]
    public void SetUp() 
    {
        gameObject = new GameObject();
        SoundEffectsController = gameObject.AddComponent<SoundEffectsController>();

        GameObject buttonObject = new GameObject();
        testButton = buttonObject.AddComponent<Button>();
        testButton.image = buttonObject.AddComponent<Image>();

        spriteOn = Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 1, 1), Vector2.zero);
        spriteOff = Sprite.Create(Texture2D.blackTexture, new Rect(0, 0, 1, 1), Vector2.zero);

        SoundEffectsController.soundEffectsButton = testButton;
        SoundEffectsController.soundEffectsOn = spriteOn;
        SoundEffectsController.soundEffectsOff = spriteOff;
    }

    [TearDown]
    public void TearDown() 
    {
        UnityEngine.Object.DestroyImmediate(gameObject);
    }

    [Test]
    public void ToggleMusic_UnmutedToMuted_Test() 
    {
        SoundEffectsController.toggleSoundEffects();

        Assert.AreEqual(spriteOff, testButton.image.sprite);
    }

    [Test]
    public void ToggleMusic_mutedToUnmuted_Test() 
    {
        SoundEffectsController.toggleSoundEffects();
        SoundEffectsController.toggleSoundEffects();

        Assert.AreEqual(spriteOn, testButton.image.sprite);
    }
}
