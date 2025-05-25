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
        // FindObjectOfType<LevelResult>().CheckVictoryCondition();
    }
    

    public void CleanAllTrashs()
    {
        LevelInfo level = levelsInitialInfo.Find(l => l.levelId == GameSessionData.LastPlayedLevel);
        Debug.Log(level.trashCount);
        GameObject[] wastes = GameObject.FindGameObjectsWithTag("Waste");
        Debug.Log("Quantidade de lixos: " + (wastes.Length - 1));

        if (level != null)
        {
            if (TrashCount >= (level.trashCount + lifes))
            { //o maior > eh temporario, enquanto n colca dados consistentes
                // chamo a cena de vitoria
                FindObjectOfType<LevelResult>().ShowPopUp("Acabou o tempo");
                Debug.Log("vc ganhou");
                AddCurrentLevel();
            }

            else if (wastes.Length - 1 == 0)
            {
                if (UserWon())
                {
                    // chamo a cena de vitoria
                    FindObjectOfType<LevelResult>().ShowPopUp("Acabou o tempo");
                    Debug.Log("vc ganhou");
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
            if ((TrashCount >= levelAux.trashCount))
            {
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    public void AddCurrentLevel()
    {
        if (PlayerCurrentLevel <= GameSessionData.LastPlayedLevel)
        {
            PlayerCurrentLevel++;

            DataPersistenceManager.Instance.SaveGame();
            Debug.Log("O nivel agr é " + PlayerCurrentLevel);
        }
        else
        {
            Debug.Log("O nivel mantem o mesmo sendo ele " + PlayerCurrentLevel);
        }
    }

    public void LoadData(GameData gameData)
    {
        PlayerCurrentLevel = gameData.PlayerCurrentLevel;
        GameInfoPhase = gameData.LevelInfosPhase;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.PlayerCurrentLevel = this.PlayerCurrentLevel;
        gameData.LevelInfosPhase = this.GameInfoPhase;
    }

    public void LoadData(LevelData levelData)
    {
        foreach(var Data in levelData.levelsInitialInfo)
        {
            levelsInitialInfo.Add(Data);
        }
    }
}
