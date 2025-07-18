using System.Collections.Generic;

[System.Serializable]
public class GameData
{
  public int PlayerCurrentLevel;
  public List<LevelInfoInPhases> LevelInfosPhase;
  public int TotalHits;
  public int TotalErrors;

  public GameData()
  {
    PlayerCurrentLevel = 1;
    LevelInfosPhase = new List<LevelInfoInPhases>();

    for (int i = 0; i < 5; i++)
    {
      LevelInfosPhase.Add(new LevelInfoInPhases
      {
        id = i + 1,
        best_time = int.MaxValue,
        highscore = 0
      });
    }

    TotalHits = 0;
    TotalErrors = 0;
  }
}

[System.Serializable]
public class LevelInfoInPhases
{
  public int id;
  public int best_time;
  public int highscore;
}
