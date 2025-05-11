using UnityEngine;
using UnityEngine.UI;

public class UpdateInfoPanelOnButtonPressed : MonoBehaviour
{
    public int LevelNumber;
    public int TrashCount;
    public float TimeInSeconds;

    public InfoPanel infoPanel;

    public void OnClickLevelButton(Button clickedButton)
    {
        string buttonName = clickedButton.name;

        switch (buttonName) 
        {
            case "LevelOne":
                LevelNumber = 1;
                break;
            case "LevelTwo":
                LevelNumber = 2;
                break;
            case "LevelThree":
                LevelNumber = 3;
                break;
            case "LevelFour":
                LevelNumber = 4;
                break;
            case "LevelFive":
                LevelNumber = 5;
                break;
        }

        
        // TODO: Read a file with all the levels and their info and return this info based on the button pressed
        TrashCount = 25;
        TimeInSeconds = 170;
        InfoPanel.Instance.UpdatePanel(LevelNumber, TrashCount, TimeInSeconds);
    }
}
