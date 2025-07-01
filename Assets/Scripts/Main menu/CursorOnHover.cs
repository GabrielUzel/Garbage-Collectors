using UnityEngine;
using UnityEngine.EventSystems;

public class CursorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  private static Texture2D handCursor;
  private static Texture2D mouseCursor;

  void Start()
  {
    if (handCursor == null)
    {
      handCursor = Resources.Load<Texture2D>("cursor_hand");
    }
    if(mouseCursor == null)
    {
      mouseCursor = Resources.Load<Texture2D>("cursor_mouse");
    }
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
    if (handCursor != null && gameObject.activeInHierarchy)
    {
      Cursor.SetCursor(handCursor, new Vector2(16, 4), CursorMode.Auto);
    }
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    Cursor.SetCursor(mouseCursor, new Vector2(5, 5), CursorMode.Auto); 
  }
}
