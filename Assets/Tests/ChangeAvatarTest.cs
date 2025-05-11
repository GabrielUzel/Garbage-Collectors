using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

public class ChangeAvatarTest
{
    private GameObject gameObject;
    private ChangeAvatar avatarController;
    private Image girlWaving;
    private Image boyWaving;
    private Image selectBoyImage;
    private Image selectGirlImage;
    private GameObject selectBoyBtn;
    private GameObject selectedBoyBtn;
    private GameObject selectGirlBtn;
    private GameObject selectedGirlBtn;
    
    [SetUp]
    public void SetUp() 
    {
        PlayerPrefs.DeleteAll();
        gameObject = new GameObject();
        avatarController = gameObject.AddComponent<ChangeAvatar>();

        girlWaving = CreateImage("girlWaving");
        boyWaving = CreateImage("boyWaving");
        selectBoyImage = CreateImage("selectBoyImage");
        selectGirlImage = CreateImage("selectGirlImage");

        selectBoyBtn = new GameObject("selectBoyBtn");
        selectedBoyBtn = new GameObject("selectedBoyBtn");
        selectGirlBtn = new GameObject("selectGirlBtn");
        selectedGirlBtn = new GameObject("selectedGirlBtn");

        avatarController.girlWaving = girlWaving;
        avatarController.boyWaving = boyWaving;
        avatarController.selectBoyImage = selectBoyImage;
        avatarController.selectGirlImage = selectGirlImage;
        avatarController.selectBoyBtn = selectBoyBtn;
        avatarController.selectedBoyBtn = selectedBoyBtn;
        avatarController.selectGirlBtn = selectGirlBtn;
        avatarController.selectedGirlBtn = selectedGirlBtn;
    }

    [TearDown]
    public void TearDown() 
    {
        UnityEngine.Object.DestroyImmediate(gameObject);
    }

    [Test]
    public void NoAvatarSelected_Test()
    {
        PlayerPrefs.DeleteAll();
        avatarController.Start();

        Assert.AreEqual(1f, girlWaving.color.a);
        Assert.AreEqual(1f, boyWaving.color.a);
        Assert.IsTrue(selectBoyBtn.activeSelf);
        Assert.IsFalse(selectedBoyBtn.activeSelf);
        Assert.IsTrue(selectGirlBtn.activeSelf);
        Assert.IsFalse(selectedGirlBtn.activeSelf);
    }

    [Test]
    public void SelectBoy_Test()
    {
        avatarController.SelectBoy();

        Assert.AreEqual("boy", PlayerPrefs.GetString("selected_avatar"));
        Assert.AreEqual(1f, selectBoyImage.color.a);
        Assert.AreEqual(0.8f, selectGirlImage.color.a);
        Assert.IsTrue(selectedBoyBtn.activeSelf);
        Assert.IsFalse(selectBoyBtn.activeSelf);
        Assert.IsFalse(selectedGirlBtn.activeSelf);
        Assert.IsTrue(selectGirlBtn.activeSelf);
    }

    [Test]
    public void SelectGirl_Test()
    {
        avatarController.SelectGirl();

        Assert.AreEqual("girl", PlayerPrefs.GetString("selected_avatar"));
        Assert.AreEqual(1f, selectGirlImage.color.a);
        Assert.AreEqual(0.8f, selectBoyImage.color.a);
        Assert.IsTrue(selectedGirlBtn.activeSelf);
        Assert.IsFalse(selectGirlBtn.activeSelf);
        Assert.IsFalse(selectedBoyBtn.activeSelf);
        Assert.IsTrue(selectBoyBtn.activeSelf);
    }

    [Test]
    public void LoadBoySelection_Test()
    {
        PlayerPrefs.SetString("selected_avatar", "boy");
        avatarController.Start();

        Assert.AreEqual(1f, boyWaving.color.a);
        Assert.AreEqual(0.8f, girlWaving.color.a);
        Assert.IsTrue(selectedBoyBtn.activeSelf);
        Assert.IsFalse(selectBoyBtn.activeSelf);
    }

    [Test]
    public void LoadGirlSelection_Test()
    {
        PlayerPrefs.SetString("selected_avatar", "girl");
        avatarController.Start();

        Assert.AreEqual(1f, girlWaving.color.a);
        Assert.AreEqual(0.8f, boyWaving.color.a);
        Assert.IsTrue(selectedGirlBtn.activeSelf);
        Assert.IsFalse(selectGirlBtn.activeSelf);
    }

    private Image CreateImage(string name)
    {
        var game_object = new GameObject(name);
        var image = game_object.AddComponent<Image>();
        image.color = new Color(1, 1, 1, 1);
        return image;
    }
}
