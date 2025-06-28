using UnityEngine;

public class CursorResetOnSceneStart : MonoBehaviour
{
  void Start()
  {
    Texture2D mouseCursor = Resources.Load<Texture2D>("cursor_mouse");

    if (mouseCursor != null)
    {
      Cursor.SetCursor(mouseCursor, new Vector2(5, 5), CursorMode.Auto);
    }
  }
}
