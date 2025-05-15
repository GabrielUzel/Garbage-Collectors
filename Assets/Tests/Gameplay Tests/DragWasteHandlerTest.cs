using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DragWasteHandlerTest
{
    public TrashType wasteType;
    private Vector3 offset;
    private bool dragging = false;

    // A Test behaves as an ordinary method
    [Test]
    public void DragWasteHandlerTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator DragWasteHandlerTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    void OnMouseDown() { }
    void OnMouseUp() { }
    void Update() { }
    private Vector3 GetMouseWorldPos() { return new Vector3(); }
}
