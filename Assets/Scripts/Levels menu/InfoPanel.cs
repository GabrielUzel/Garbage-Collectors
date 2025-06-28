using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
  public static InfoPanel Instance;
  [SerializeField] public Text LevelText;
  public Text TrashText;
  public Text TimeText;

  public void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
  }

  public void UpdatePanel(int level, int trash, int timeInSeconds)
  {
    LevelText.text = level.ToString();
    TrashText.text = trash.ToString();

    int minutes = timeInSeconds  / 60;
    int seconds = timeInSeconds  % 60;
    TimeText.text = $"{minutes}:{seconds:00}";
  }
}
