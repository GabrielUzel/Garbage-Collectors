using System.Collections.Generic;

[System.Serializable]
public class LevelInfo
{
  public int levelId;
  public int trashCount;
  public int timeInSeconds;
  public int lifes;

  public LevelInfo()
  {

  }
}

[System.Serializable]
public class LevelData
{
  public int totalLevels;
  public List<LevelInfo> levelsInitialInfo = new List<LevelInfo>();
}
