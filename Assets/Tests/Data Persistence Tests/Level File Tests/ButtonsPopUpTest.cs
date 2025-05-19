using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ButtonsPopUpTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ButtonsPopUpTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ButtonsPopUpTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    public void LoadLevelsMenuScene_Test() { }
    public void RetryCurrentLevel_Test() {}
}
