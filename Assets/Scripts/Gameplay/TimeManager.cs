using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    public float timeRemaining;
    public bool timerIsRunning = false;
    [SerializeField] TextMeshProUGUI timeText;

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

    private void Start()
    {
        timeRemaining = LoadLevelsInfo.Instance.GetTimeInSeconds();
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

                var userWon = TrashCountManager.Instance.VerifyIfPlayerWon();

                if (userWon)
                {
                    LevelResult.Instance.ShowPopUp("Victory");
                }
                else
                {
                    LevelResult.Instance.ShowPopUp("Time");
                }
            }
        }
    }
}