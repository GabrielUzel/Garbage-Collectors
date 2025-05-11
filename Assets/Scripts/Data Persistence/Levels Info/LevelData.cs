using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class LevelInfo
{
    public int levelId;
    public int trashCount;
    public int timeInSeconds;
}

[System.Serializable]
public class LevelData
{
    public List<LevelInfo> levelsInitialInfo;
}
