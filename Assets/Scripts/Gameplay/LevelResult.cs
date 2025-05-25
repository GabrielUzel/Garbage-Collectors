using UnityEngine;
using UnityEngine.UI;

public class LevelResult : MonoBehaviour
{
    public GameObject TrashOk, TrashNotOk, TimeOk, TimeNotOk;
    public GameObject PanelPopUp;
    public GameObject Fade;
    public Text TrashText;
    public Text TimeText;
    public Text ScoreText;
    public Text Level;
    public GameObject RestartLevel;
    public GameObject NextLevel;
    public GameObject RetryLevel;
    public SpriteRenderer Background;
    private TimeManager timeManager;
    private bool victory = false;
    private float timer;
    private bool gameFinished = false;
    [SerializeField] private int tempoLimiteSegundos = 150;

    public void Start()
    {
        PanelPopUp.SetActive(false);
        timeManager = FindObjectOfType<TimeManager>();
    }

    public void Update()
    {
        if (!gameFinished)
        {
            timer += Time.deltaTime;

            if (timer >= tempoLimiteSegundos)
            {
                ShowPopUp("Tempo esgotado");
            }
        }
    }

    public void ShowPopUp(string reason)
    {
        int level = GameSessionData.LastPlayedLevel;

        LevelInfo currentLevel = null;
        if (TrashCountManager.Instance != null && TrashCountManager.Instance.levelsInitialInfo != null)
        {
            currentLevel = TrashCountManager.Instance.levelsInitialInfo
                .Find(l => l.levelId == level);
        }

        if (gameFinished)
        {
            return;
        }

        gameFinished = true;
        PanelPopUp.SetActive(true);
        Fade.SetActive(true);

        if (timeManager != null)
        {
            timeManager.timerIsRunning = false;
        }

        int wastesObjective = 0;
        int timeObjective = 0;

        if (currentLevel != null)
        {
            wastesObjective = currentLevel.trashCount;
            timeObjective = currentLevel.timeInSeconds;
        }

        int rightWastes = TrashCountManager.Instance.TrashCount;
        int score = rightWastes * 200;

        int timeWasted = Mathf.FloorToInt(timer);
        int minutes = timeWasted / 60;
        int seconds = timeWasted % 60;

        int minutesObjective = timeObjective / 60;
        int secondsObjective = timeObjective % 60;

        Level.text = $"{level}";
        ScoreText.text = $"PONTUAÇÃO: {score}";
        TrashText.text = $"{rightWastes}/{wastesObjective}";
        TimeText.text = $"{minutes}:{seconds:00}/{minutesObjective}:{secondsObjective:00}";

        victory = rightWastes >= wastesObjective && timeWasted <= timeObjective;

        CheckVictoryCondition();
    }

    public void CheckVictoryCondition()
    {
        TrashOk.SetActive(false);
        TrashNotOk.SetActive(false);
        TimeOk.SetActive(false);
        TimeNotOk.SetActive(false);

        int level = GameSessionData.LastPlayedLevel;

        LevelInfo currentLevel = TrashCountManager.Instance.levelsInitialInfo
            .Find(l => l.levelId == level);

        int wastesObjective = currentLevel.trashCount;
        int timeObjective = currentLevel.timeInSeconds;
        int rightWastes = TrashCountManager.Instance.TrashCount;
        int timeWasted = Mathf.FloorToInt(timer);

        if (rightWastes >= wastesObjective)
        {
            TrashOk.SetActive(true);
        }
        else
        {
            TrashNotOk.SetActive(true);
        }

        if (timeWasted <= timeObjective)
        {
            TimeOk.SetActive(true);
        }
        else
        {
            TimeNotOk.SetActive(true);
        }

        if (victory)
        {
            RestartLevel.SetActive(true);
            NextLevel.SetActive(true);
            RetryLevel.SetActive(false);
        }
        else
        {
            RestartLevel.SetActive(false);
            NextLevel.SetActive(false);
            RetryLevel.SetActive(true);
        }
    }  
}
