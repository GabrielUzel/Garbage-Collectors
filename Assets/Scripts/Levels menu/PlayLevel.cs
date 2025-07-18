using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayLevel : MonoBehaviour, ILevelPersistence
{
  public GameObject PopUpPanel;
  public GameObject LevelButtonsGroup;
  public Button ReturnToHomeButton;
  public GameObject FadedBackground;
  private readonly List<Button> ActiveButtons = new();
  private int LevelId;
  private int TrashCount;
  private int TimeInSeconds;
  private LevelData levelData;

  void Start()
  {
    PopUpPanel.SetActive(false);
  }

  public void LoadPopUp(Button clickedButton)
  {
    PopUpPanel.SetActive(true);
    ReturnToHomeButton.interactable = false;

    foreach (Transform child in LevelButtonsGroup.transform)
    {
      Button btn = child.GetComponent<Button>();

      if (btn != null && btn.interactable && btn != clickedButton) {
        btn.interactable = false;
        ActiveButtons.Add(btn);
      }
    }

    FadedBackground.SetActive(true);
    OnClickLevelButton(clickedButton);
  }

  public void OnClickLevelButton(Button clickedButton)
  {
    string buttonName = clickedButton.name;

    switch (buttonName) 
    {
      case "LevelOne":
        LevelId = 1;
        break;
      case "LevelTwo":
        LevelId = 2;
        break;
      case "LevelThree":
        LevelId = 3;
        break;
      case "LevelFour":
        LevelId = 4;
        break;
      case "LevelFive":
        LevelId = 5;
        break;
    }
    
    GameSessionData.LastPlayedLevel = LevelId;

    UpdateLevelInfo(LevelId);
    InfoPanel.Instance.UpdatePanel(LevelId, TrashCount, TimeInSeconds);
  }

  public void LoadData(LevelData levelData)
  {
    this.levelData = levelData;
  }

  public void UpdateLevelInfo(int levelId)
  {
    LevelInfo currentLevelInfo = levelData.levelsInitialInfo.Find(info => info.levelId == levelId);
    TrashCount = currentLevelInfo.trashCount;
    TimeInSeconds = currentLevelInfo.timeInSeconds;
  }

  public void ClosePopUp()
  {
    PopUpPanel.SetActive(false);
    ReturnToHomeButton.interactable = true;

    foreach (Button btn in ActiveButtons)
    {
      btn.interactable = true;
    }

    ActiveButtons.Clear();
    FadedBackground.SetActive(false);

    Texture2D mouseCursor = Resources.Load<Texture2D>("cursor_mouse");
    if (mouseCursor != null)
    {
      Cursor.SetCursor(mouseCursor, new Vector2(5, 5), CursorMode.Auto);
    }
  }

  public int GetLevelId()
  {
    return LevelId;
  }

  public int GetTrashCount()
  {
    return TrashCount;
  }

  public int GetTimeInSeconds()
  {
    return TimeInSeconds;
  }
}