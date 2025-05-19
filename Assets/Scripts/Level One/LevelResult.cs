using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Level_One;
using UnityEngine.SceneManagement;

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

    private bool vitoria = false;

    private float timer;
    private bool jogoFinalizado = false;

    public void Start()
    {
        PanelPopUp.SetActive(false);
        timeManager = FindObjectOfType<TimeManager>();
    }

    [SerializeField] private int tempoLimiteSegundos = 150;

    void Update()
    {
        if (!jogoFinalizado)
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
        int nivel = GameSessionData.LastPlayedLevel;

        LevelInfo nivelAtual = null;
        if (TrashCountManager.Instance != null && TrashCountManager.Instance.levelsInitialInfo != null)
        {
            nivelAtual = TrashCountManager.Instance.levelsInitialInfo
                .Find(l => l.levelId == nivel);
        }

        if (jogoFinalizado) return;
        jogoFinalizado = true;

        PanelPopUp.SetActive(true);
        Fade.SetActive(true);

        if (timeManager != null)
        {
            timeManager.timerIsRunning = false;
        }

        int objetivoLixos = 0;
        int tempoObjetivo = 0;

        if (nivelAtual != null)
        {
            objetivoLixos = nivelAtual.trashCount;
            tempoObjetivo = nivelAtual.timeInSeconds;
        }

        int lixosCorretos = TrashCountManager.Instance.TrashCount;
        int pontuacao = lixosCorretos * 200;

        int tempoGasto = Mathf.FloorToInt(timer);
        int min = tempoGasto / 60;
        int seg = tempoGasto % 60;

        int minObjetivo = tempoObjetivo / 60;
        int segObjetivo = tempoObjetivo % 60;

        Level.text = $"{nivel}";
        ScoreText.text = $"PONTUAÇÃO: {pontuacao}";
        TrashText.text = $"{lixosCorretos}/{objetivoLixos}";
        TimeText.text = $"{min}:{seg:00}/{minObjetivo}:{segObjetivo:00}";

        Debug.Log($"[LevelResult] Fim do jogo");

        vitoria = (lixosCorretos >= objetivoLixos && tempoGasto <= tempoObjetivo);

        CheckVictoryCondition();
    }

    public void CheckVictoryCondition()
    {
        TrashOk.SetActive(false);
        TrashNotOk.SetActive(false);
        TimeOk.SetActive(false);
        TimeNotOk.SetActive(false);

        int nivel = GameSessionData.LastPlayedLevel;

        LevelInfo nivelAtual = TrashCountManager.Instance.levelsInitialInfo
            .Find(l => l.levelId == nivel);

        int objetivoLixos = nivelAtual.trashCount;
        int tempoObjetivo = nivelAtual.timeInSeconds;
        int lixosCorretos = TrashCountManager.Instance.TrashCount;
        int tempoGasto = Mathf.FloorToInt(timer);

        if (lixosCorretos >= objetivoLixos)
            TrashOk.SetActive(true);
        else
            TrashNotOk.SetActive(true);

        if (tempoGasto <= tempoObjetivo)
            TimeOk.SetActive(true);
        else
            TimeNotOk.SetActive(true);

        if (vitoria)
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
    public void RetryCurrentLevel()
{
    Scene sceneAtual = SceneManager.GetActiveScene();
    SceneManager.LoadScene(sceneAtual.name);
}
   
}
