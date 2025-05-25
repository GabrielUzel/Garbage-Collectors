using System.Collections.Generic;
using UnityEngine;

public class TrashCountManager : MonoBehaviour, IDataPersistence, ILevelPersistence
{
    public static TrashCountManager Instance;
    public int TrashCount = 0;
    public GameData GameData;
    public List<LevelInfoInPhases> GameInfoPhase;
    public int PlayerCurrentLevel;
    public int LastPlayedLevel; 

    public LevelData LevelDatas;
    public List<LevelInfo> levelsInitialInfo;

    public int lifes = 9;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddTrashCount()
    {
        TrashCount++;
        CleanAllTrashs();
    }
    

    public void CleanAllTrashs()
    {
        LevelInfo level = levelsInitialInfo.Find(l => l.levelId == GameSessionData.LastPlayedLevel);
        GameObject[] wastes = GameObject.FindGameObjectsWithTag("Waste");

        if (level != null)
        {
            if (TrashCount >= (level.trashCount + lifes))
            { 
                FindObjectOfType<LevelResult>().ShowPopUp("Acabou o tempo");
                AddCurrentLevel();
            }

            if (wastes.Length - 1 == 0)
            {
                if (UserWon())
                {
                    FindObjectOfType<LevelResult>().ShowPopUp("Acabou o tempo");
                    AddCurrentLevel();
                }
            }
        }
    }

    public bool UserWon()
    {
        LevelInfo levelAux = levelsInitialInfo.Find(l => l.levelId == PlayerCurrentLevel);
        if (levelAux != null)
        {
            if (TrashCount >= levelAux.trashCount)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public void AddCurrentLevel()
    {
        if (PlayerCurrentLevel <= GameSessionData.LastPlayedLevel)
        {
            PlayerCurrentLevel++;

            DataPersistenceManager.Instance.SaveGame();
        }
    }

    public void LoadData(GameData gameData)
    {
        PlayerCurrentLevel = gameData.PlayerCurrentLevel;
        GameInfoPhase = gameData.LevelInfosPhase;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.PlayerCurrentLevel = PlayerCurrentLevel;
        gameData.LevelInfosPhase = GameInfoPhase;
    }

    public void LoadData(LevelData levelData)
    {
        foreach(var Data in levelData.levelsInitialInfo)
        {
            levelsInitialInfo.Add(Data);
        }
    }
}
