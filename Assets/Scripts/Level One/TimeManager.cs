using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Level_One
{
    public class TimeManager : MonoBehaviour, ILevelPersistence
    {
        public float timeRemaining;
        public bool timerIsRunning = false;
        [SerializeField] TextMeshProUGUI timeText;
        private LevelData levelData;

        private void Start()
        {
            LevelInfo currentLevelInfo = levelData.levelsInitialInfo.Find(info => info.levelId == GameSessionData.LastPlayedLevel);
            timeRemaining = currentLevelInfo.timeInSeconds;
            Debug.Log("Tempo: " +  timeRemaining);
            timerIsRunning = true;
        }

        public void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        void Update()
        {
            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                    timeRemaining = 0;
                    timerIsRunning = false;

                    var userWon = TrashCountManager.Instance.UserWon();
                    if (userWon)
                    {
                        Debug.Log("vc ganhou");
                        FindObjectOfType<LevelResult>().ShowPopUp("Você venceu!");
                        TrashCountManager.Instance.AddCurrentLevel();
                        // chamar tela de vitoria
                    }
                    else
                    {
                        Debug.Log("Tempo acabou e vc perdeu");
                        FindObjectOfType<LevelResult>().ShowPopUp("Acabou o tempo");
                        //chamar tela de derrota
                    }



                }
            }
        }

 
        public void LoadData(LevelData levelData)
        {
            this.levelData = levelData;
        }

    }
}