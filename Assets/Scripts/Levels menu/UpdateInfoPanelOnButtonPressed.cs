using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class UpdateInfoPanelOnButtonPressed : MonoBehaviour, ILevelPersistence
{
    private int LevelId;
    private int TrashCount;
    private float TimeInSeconds;
    private InfoPanel infoPanel;
    private LevelData levelData;

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
}
