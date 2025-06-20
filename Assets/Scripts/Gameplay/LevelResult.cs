using UnityEngine;
using UnityEngine.UI;

public class LevelResult : MonoBehaviour
{
    public AudioClip sound;           
    private AudioSource audioSrc;
    public static LevelResult Instance;
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
    private int levelId;
    private int trashes;
    private int timeInSeconds;
    public GameData GameData;
    public int PlayerCurrentLevel;
    public bool victory = false;

    public bool userWon = false;

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

    public void Start()
    {
        if (audioSrc == null)
            audioSrc = gameObject.AddComponent<AudioSource>();
        levelId = LoadLevelsInfo.Instance.GetLevelId();
        trashes = LoadLevelsInfo.Instance.GetTotalWaste();
        timeInSeconds = LoadLevelsInfo.Instance.GetTimeInSeconds();

        PanelPopUp.SetActive(false);

        TrashOk.SetActive(false);
        TrashNotOk.SetActive(false);
        TimeOk.SetActive(false);
        TimeNotOk.SetActive(false);
    }

    public void ShowPopUp(string reason)
    {
        audioSrc.PlayOneShot(sound);
        TimeManager.Instance.timerIsRunning = false;
        PanelPopUp.SetActive(true);
        Fade.SetActive(true);

        int correctWastes = TrashCountManager.Instance.CorrectTrashCount;
        int score = ScoreManager.Instance.score;

        int timeWasted = Mathf.FloorToInt(timeInSeconds - TimeManager.Instance.timeRemaining);
        int minutesWasted = timeWasted / 60;
        int secondsWasted = timeWasted % 60;

        int minutesObjective = timeInSeconds / 60;
        int secondsObjective = timeInSeconds % 60;

        Level.text = $"{levelId}";
        ScoreText.text = $"PONTUAÇÃO: {score}";
        TrashText.text = $"{correctWastes}/{trashes}";
        TimeText.text = $"{minutesWasted}:{secondsWasted:00}/{minutesObjective}:{secondsObjective:00}";

        UpdateUI(reason);
        GameProgressSaver.Instance.UpdateSaveFile(levelId, GameSessionData.LastPlayedLevel, timeWasted, score, userWon);
    }

    private void UpdateUI(string reason)
    {
        if (reason == "Time")
        {
            if (victory)
            {
                TimeOk.SetActive(true);
                TrashOk.SetActive(true);
                RestartLevel.SetActive(true);
                NextLevel.SetActive(true);
                RetryLevel.SetActive(false);
                userWon = true;
            }
            else
            {
                TrashNotOk.SetActive(true);
                TimeNotOk.SetActive(true);
                RetryLevel.SetActive(true);
                userWon = false;
            }

            return;
        }

        if (reason == "Life")
        {
            TimeOk.SetActive(true);
            TrashNotOk.SetActive(true);
            RetryLevel.SetActive(true);
            userWon = false;
            return;
        }

        TimeOk.SetActive(true);
        TrashOk.SetActive(true);
        RestartLevel.SetActive(true);
        NextLevel.SetActive(true);
        RetryLevel.SetActive(false);
        userWon = true;
    }
}
