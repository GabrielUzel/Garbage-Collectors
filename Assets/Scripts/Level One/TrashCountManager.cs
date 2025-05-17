
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Level_One
{
    public class TrashCountManager : MonoBehaviour, IDataPersistence
    {
        public static TrashCountManager Instance;
        public int TrashCount = 0;
        public GameData GameData;
        public LevelData LevelDatas;
        public int level;
      //  public List<LevelInfo> levelsInitialInfo;



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
            Debug.Log("chegou ate aq");
           // CleanAllTrashs();
        }

        public void CleanAllTrashs()
        {
           
            Debug.Log(level);
          
          //  Debug.Log(levelInfo);
            /*
            LevelInfo levelInfo = LevelPersistenceImplementation.Instance.GetLevelInfo(currentLevel);
            Debug.Log("Conteúdo do arquivo JSON:\n" + levelInfo);

            Debug.Log(levelInfo);
            if (levelInfo != null)
            {
                if(TrashCount == 2){
                    // chamo a cena de vitoria
                    Debug.Log("vc ganhou");
                }
            }
        */
        
    }

        public void LoadData(GameData gameData)
        {
           level = gameData.PlayerCurrentLevel;
        }

        public void SaveData(ref GameData gameData)
        {
            throw new NotImplementedException();
        }

       
    }
}
