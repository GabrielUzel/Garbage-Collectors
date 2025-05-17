
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Level_One
{
    public class TrashCountManager : MonoBehaviour, IDataPersistence, ILevelPersistence
    {
        public static TrashCountManager Instance;
        public int TrashCount = 0;
        public GameData GameData;
        public List<LevelInfoInPhases> GameInfoPhase;
        public int PlayerCurrentLevel;


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
            LevelInfo level = levelsInitialInfo.Find(l => l.levelId == PlayerCurrentLevel);
            Debug.Log(level.trashCount);

            if (level != null)
            {
                Debug.Log(level.trashCount);
                Debug.Log(lifes);
                Debug.Log(TrashCount);
                if(TrashCount == (level.trashCount + lifes)){
                    // chamo a cena de vitoria
                    // SceneManager.LoadScene("Victory_Scene");
                    AddCurrentLevel();
                }
            }

        }

        public bool UserWon()
        {
            LevelInfo levelAux = levelsInitialInfo.Find(l => l.levelId == PlayerCurrentLevel);
            if (levelAux != null)
            {
                if((TrashCount >= levelAux.trashCount)){
                    return true;
                }
                return false;
            }
            else { return false; }
           
        }

        public void AddCurrentLevel()
        {
            PlayerCurrentLevel++;

            DataPersistenceManager.Instance.SaveGame();
            Debug.Log("O nivel agr é " + PlayerCurrentLevel);
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
}
