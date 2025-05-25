using UnityEngine;

public class TrashCountManager : MonoBehaviour, ILevelPersistence
{
    public static TrashCountManager Instance;
    public int CorrectTrashCount = 0;
    public int IncorrectTrashCount = 0;
    public GameData GameData;
    public LevelData LevelData;
    private LevelInfo currentLevelInfo;
    private int trashes;
    private int totalTrashes;

    void Awake()
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

    void Start()
    {
        currentLevelInfo = LevelData.levelsInitialInfo.Find(info => info.levelId == GameSessionData.LastPlayedLevel);
        trashes = currentLevelInfo.trashCount;
        totalTrashes = trashes * 100 / 70;
    }

    void Update()
    {
        if (CorrectTrashCount + IncorrectTrashCount == totalTrashes)
        {
            TimeManager.Instance.timerIsRunning = false;
            LevelResult.Instance.ShowPopUp("Victory");
        }
    }

    public void AddCorrectTrashCount()
    {
        CorrectTrashCount++;

        if (VerifyIfPlayerWon())
        {
            LevelResult.Instance.victory = true;
        }
    }

    public void AddIncorrectTrashCount()
    {
        IncorrectTrashCount++;
    }

    public bool VerifyIfPlayerWon()
    {
        if (CorrectTrashCount == trashes * 70 / 100)
        {
            return true;
        }

        return false;
    }

    public void CleanAllTrashes()
    {
        GameObject[] wastes = GameObject.FindGameObjectsWithTag("Waste");

        foreach (GameObject waste in wastes)
        {
            Destroy(waste);
        }
    }

    public void LoadData(LevelData levelData)
    {
        LevelData = levelData;
    }
}
