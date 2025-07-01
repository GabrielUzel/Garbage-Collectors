using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

public class AvatarTest
{
  private GameObject avatarGameObject;
  private Avatar avatar;
  private SpriteRenderer spriteRenderer;

  [SetUp]
  public void SetUp()
  {
    avatarGameObject = new GameObject();
    avatar = avatarGameObject.AddComponent<Avatar>();
    spriteRenderer = avatarGameObject.AddComponent<SpriteRenderer>();
    avatar.spriteRenderer = spriteRenderer;
    avatar.avatar = new GameObject();
    
    avatar.sprites = new Sprite[6];
    for (int i = 0; i < 6; i++)
    {
      avatar.sprites[i] = Sprite.Create(new Texture2D(1, 1), new Rect(0, 0, 1, 1), Vector2.zero);
    }
    
    typeof(Avatar).GetField("totalWaste", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(avatar, 10);
  }

  [TearDown]
  public void TearDown()
  {
    Object.DestroyImmediate(avatarGameObject);
    Object.DestroyImmediate(avatar.avatar);
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
    avatar.spriteRenderer.sprite = avatar.sprites[0];
    avatar.UpdateSprite(2, true, avatar.spriteRenderer);
    Assert.AreEqual(avatar.sprites[0], avatar.spriteRenderer.sprite); 
  }

  [Test]
  public void VerifyCorrectSprite_InitialValue_GirlSelected_Test()
  {
    avatar.spriteRenderer.sprite = avatar.sprites[3];
    avatar.UpdateSprite(2, false, avatar.spriteRenderer);
    Assert.AreEqual(avatar.sprites[3], avatar.spriteRenderer.sprite);
  }

  [Test]
  public void VerifyCorrectSprite_60Percentage_BoySelected_Test()
  {
    avatar.UpdateSprite(6, true, avatar.spriteRenderer);
    Assert.AreEqual(avatar.sprites[1], avatar.spriteRenderer.sprite);
  }

  [Test]
  public void VerifyCorrectSprite_60Percentage_GirlSelected_Test()
  {
    avatar.UpdateSprite(6, false, avatar.spriteRenderer);
    Assert.AreEqual(avatar.sprites[4], avatar.spriteRenderer.sprite);
  }

  [Test]
  public void VerifyCorrectSprite_100Percentage_BoySelected_Test()
  {
    avatar.UpdateSprite(10, true, avatar.spriteRenderer);
    Assert.AreEqual(avatar.sprites[2], avatar.spriteRenderer.sprite);
  }

  [Test]
  public void VerifyCorrectSprite_100Percentage_GirlSelected_Test()
  {
    avatar.UpdateSprite(10, false, avatar.spriteRenderer);
    Assert.AreEqual(avatar.sprites[5], avatar.spriteRenderer.sprite);
  }

  [Test]
  [TestCase(1, 124f, -22.3f)]
  [TestCase(2, -86f, -29.3f)]
  [TestCase(3, 69.5f, 0.1f)]
  [TestCase(4, -115.1f, -45.9f)]
  [TestCase(5, -123.6f, -43.7f)]
  public void VerifyAvatarPosition_Test(int levelId, float x, float y)
  {
    MethodInfo method = typeof(Avatar).GetMethod("DefineAvatarPosition", BindingFlags.NonPublic | BindingFlags.Instance);
    method.Invoke(avatar, new object[] { levelId });
    Vector3 expected = new(x, y, 0);
    Assert.AreEqual(expected, avatar.avatar.transform.position);
  }
}