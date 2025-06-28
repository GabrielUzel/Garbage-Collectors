using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class AvatarInitializerTests
{
  private GameObject testObject;
  private AvatarInitializer avatarInitializer;
  private GameObject girlAvatar;
  private GameObject boyAvatar;

  [SetUp]
  public void SetUp()
  {
    PlayerPrefs.DeleteAll();

    testObject = new GameObject();
    avatarInitializer = testObject.AddComponent<AvatarInitializer>();

    girlAvatar = new GameObject();
    boyAvatar = new GameObject();
    avatarInitializer.girlAvatar = girlAvatar;
    avatarInitializer.boyAvatar = boyAvatar;

    girlAvatar.SetActive(true);
    boyAvatar.SetActive(true);
  }

  [TearDown]
  public void TearDown()
  {
    Object.DestroyImmediate(testObject);
    Object.DestroyImmediate(girlAvatar);
    Object.DestroyImmediate(boyAvatar);
  }

  [Test]
  public void GirlIsSelected_Test()
  {
    PlayerPrefs.SetString("selected_avatar", "girl");
    avatarInitializer.Start();

    Assert.IsTrue(girlAvatar.activeSelf, "Girl avatar should be active by default");
    Assert.IsFalse(boyAvatar.activeSelf, "Boy avatar should be inactive by default");
  }

  [Test]
  public void BoyIsSelected_Test()
  {
    PlayerPrefs.SetString("selected_avatar", "boy");
    avatarInitializer.Start();

    Assert.IsTrue(boyAvatar.activeSelf, "Boy avatar should be active when selected");
    Assert.IsFalse(girlAvatar.activeSelf, "Girl avatar should be inactive when boy is selected");
  }
}