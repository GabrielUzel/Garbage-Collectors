using Assets.Scripts.Level_One;
using UnityEngine;

public class GameProgressSaver : MonoBehaviour, IDataPersistence
{
    public TimeManager timeManager;
    public float timeLevelOne = 150;
    public int idSceneLevelOne = 3;

    public void LoadData(GameData data)
    {

    }

    public void SaveData(ref GameData data)
    {
        int currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - idSceneLevelOne;
        float timeSpent = timeLevelOne - timeManager.timeRemaining;
        int score = ScoreManager.Instance.score;

        LevelInfoInPhases levelInfo = data.LevelInfosPhase.Find(l => l.id == currentLevel);

        if (levelInfo != null)
        {
            if (levelInfo.best_time == -1 || timeSpent < levelInfo.best_time)
            {
                levelInfo.best_time = Mathf.FloorToInt(timeSpent); 
            }

            if (score > levelInfo.highscore)
            {
                levelInfo.highscore = score;
            }
        }
    }
}
