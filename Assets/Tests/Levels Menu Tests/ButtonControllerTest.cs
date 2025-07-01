using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[TestFixture]
public class ButtonControllerTests
{
  private ButtonController buttonController;

  [SetUp]
  public void Setup()
  {
    GameObject buttonControllerObject = new GameObject();
    buttonController = buttonControllerObject.AddComponent<ButtonController>();

    buttonController.LevelOne = CreateButtonWithImage();
    buttonController.LevelTwo = CreateButtonWithImage();
    buttonController.LevelThree = CreateButtonWithImage();
    buttonController.LevelFour = CreateButtonWithImage();
    buttonController.LevelFive = CreateButtonWithImage();

    buttonController.ImageButtonTwo = buttonController.LevelTwo.GetComponent<Image>();
    buttonController.ImageButtonThree = buttonController.LevelThree.GetComponent<Image>();
    buttonController.ImageButtonFour = buttonController.LevelFour.GetComponent<Image>();
    buttonController.ImageButtonFive = buttonController.LevelFive.GetComponent<Image>();
  }

  private Button CreateButtonWithImage()
  {
    GameObject buttonObject = new();
    buttonObject.AddComponent<Image>();
    
    return buttonObject.AddComponent<Button>();
  }

  [Test]
  public void PlayerCurrentLevel1_Test()
  {
    buttonController.PlayerCurrentLevel = 1;

    buttonController.Start();

    Assert.IsTrue(buttonController.LevelOne.interactable);
    Assert.IsFalse(buttonController.LevelTwo.interactable);
    Assert.IsFalse(buttonController.LevelThree.interactable);
    Assert.IsFalse(buttonController.LevelFour.interactable);
    Assert.IsFalse(buttonController.LevelFive.interactable);

    Assert.AreEqual(1f, buttonController.ImageButtonTwo.color.a);
    Assert.AreEqual(1f, buttonController.ImageButtonThree.color.a);
    Assert.AreEqual(1f, buttonController.ImageButtonFour.color.a);
    Assert.AreEqual(1f, buttonController.ImageButtonFive.color.a);
  }

  [Test]
  public void PlayerCurrentLevel2_Test()
  {
    buttonController.PlayerCurrentLevel = 2;

    buttonController.Start();

    Assert.IsTrue(buttonController.LevelOne.interactable);
    Assert.IsTrue(buttonController.LevelTwo.interactable);
    Assert.IsFalse(buttonController.LevelThree.interactable);
    Assert.IsFalse(buttonController.LevelFour.interactable);
    Assert.IsFalse(buttonController.LevelFive.interactable);

    Assert.AreEqual(0f, buttonController.ImageButtonTwo.color.a);
    Assert.AreEqual(1f, buttonController.ImageButtonThree.color.a);
    Assert.AreEqual(1f, buttonController.ImageButtonFour.color.a);
    Assert.AreEqual(1f, buttonController.ImageButtonFive.color.a);        
  }

  [Test]
  public void PlayerCurrentLevel3_Test()
  {
    buttonController.PlayerCurrentLevel = 3;

    buttonController.Start();

    Assert.IsTrue(buttonController.LevelOne.interactable);
    Assert.IsTrue(buttonController.LevelTwo.interactable);
    Assert.IsTrue(buttonController.LevelThree.interactable);
    Assert.IsFalse(buttonController.LevelFour.interactable);
    Assert.IsFalse(buttonController.LevelFive.interactable);

    Assert.AreEqual(0f, buttonController.ImageButtonTwo.color.a);
    Assert.AreEqual(0f, buttonController.ImageButtonThree.color.a);
    Assert.AreEqual(1f, buttonController.ImageButtonFour.color.a);
    Assert.AreEqual(1f, buttonController.ImageButtonFive.color.a);        
  }

  [Test]
  public void PlayerCurrentLevel4_Test()
  {
    buttonController.PlayerCurrentLevel = 4;

    buttonController.Start();

    Assert.IsTrue(buttonController.LevelOne.interactable);
    Assert.IsTrue(buttonController.LevelTwo.interactable);
    Assert.IsTrue(buttonController.LevelThree.interactable);
    Assert.IsTrue(buttonController.LevelFour.interactable);
    Assert.IsFalse(buttonController.LevelFive.interactable);

    Assert.AreEqual(0f, buttonController.ImageButtonTwo.color.a);
    Assert.AreEqual(0f, buttonController.ImageButtonThree.color.a);
    Assert.AreEqual(0f, buttonController.ImageButtonFour.color.a);
    Assert.AreEqual(1f, buttonController.ImageButtonFive.color.a);        
  }

  [Test]
  public void PlayerCurrentLevel5_Test()
  {
    buttonController.PlayerCurrentLevel = 5;

    buttonController.Start();

    Assert.IsTrue(buttonController.LevelOne.interactable);
    Assert.IsTrue(buttonController.LevelTwo.interactable);
    Assert.IsTrue(buttonController.LevelThree.interactable);
    Assert.IsTrue(buttonController.LevelFour.interactable);
    Assert.IsTrue(buttonController.LevelFive.interactable);

    Assert.AreEqual(0f, buttonController.ImageButtonTwo.color.a);
    Assert.AreEqual(0f, buttonController.ImageButtonThree.color.a);
    Assert.AreEqual(0f, buttonController.ImageButtonFour.color.a);
    Assert.AreEqual(0f, buttonController.ImageButtonFive.color.a);        
  }

  [Test]
  public void LoadData_Test()
  {
    GameData testData = new() { PlayerCurrentLevel = 4 };
    buttonController.LoadData(testData);

    Assert.AreEqual(4, buttonController.PlayerCurrentLevel);
  }
}