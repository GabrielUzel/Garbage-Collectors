using UnityEngine;

public class CursorManager : MonoBehaviour
{
  public static CursorManager Instance;
  public Texture2D defaultCursor;

  void Awake()
  {      
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
      ApplyCursor();
    }
    else
    {
      Destroy(gameObject); 
    }
  }

  public void ApplyCursor()
  {
    if (defaultCursor != null)
    {
      Cursor.SetCursor(defaultCursor, new Vector2(5, 5), CursorMode.Auto);
    }
  }

  public void ResetCursor()
  {
    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
  }
}
