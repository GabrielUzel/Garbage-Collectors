using Assets.Scripts.Level_One;
using UnityEngine;

public class GameProgressSaver : MonoBehaviour, IDataPersistence
{
    public TimeManager timeManager;

    public void LoadData(GameData data)
    {
        
    }

    public void SaveData(ref GameData data)
    {
        data.PlayerCurrentLevel = 1; 
        data.timeInSeconds = 150f - timeManager.timeRemaining; 
        data.trashCount = ScoreManager.Instance.score;
    }
}
