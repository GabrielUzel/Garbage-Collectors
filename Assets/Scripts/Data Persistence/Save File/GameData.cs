using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class GameData
{

    [System.NonSerialized]
    public int PlayerCurrentLevel;
    [System.NonSerialized]
    public int trashCount;
    [System.NonSerialized]
    public float timeInSeconds;
    public List<LevelInfoInPhases> LevelInfosPhase;

    public GameData()
    {
        PlayerCurrentLevel = 1;
        trashCount = 0;
        timeInSeconds = 0f;
        LevelInfosPhase = new List<LevelInfoInPhases>();

        for (int i = 0; i < 5; i++)
        {
            LevelInfosPhase.Add(new LevelInfoInPhases
            {
                id = i + 1,
                best_time = -1,
                highscore = 0
            });
        }
    }

    //public object LevelInfosPhase { get; internal set; }
}

[System.Serializable]
public class LevelInfoInPhases
{
    public int id;
    public int best_time;
    public int highscore;

}