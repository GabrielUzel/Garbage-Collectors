using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LevelResult
{
    // A Test behaves as an ordinary method
    [Test]
    public void LevelResultSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator LevelResultWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    public void Start_Test() { }
    public void Uptade_Test() { }
    public void ShowPopUp_Test() { }
    public void CheckVictoryCondition_Test() { }
}
