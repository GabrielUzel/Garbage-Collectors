using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TrashCountManagerTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void TrashCountManagerTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TrashCountManagerTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    private void Awake() { }
    public void AddTrashCount() { }
    public void CleanAllTrashs() { }
    public bool UserWon() { return false; }
    public void AddCurrentLevel() { }
    public void LoadData(GameData gameData) { }
    public void SaveData(ref GameData gameData) { }
    public void LoadData(LevelData levelData) { }


}
