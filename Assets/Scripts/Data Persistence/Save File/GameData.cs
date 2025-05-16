using UnityEngine;

[System.Serializable]
public class GameData
{
    public int PlayerCurrentLevel;
    public int trashCount;
    public float timeInSeconds;

    public GameData()
    {
        PlayerCurrentLevel = 1;
        trashCount = 0;
        timeInSeconds = 0f;
    }
}
