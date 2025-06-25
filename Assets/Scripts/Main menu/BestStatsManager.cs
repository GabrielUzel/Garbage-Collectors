using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class BestStatsManager : MonoBehaviour, IDataPersistence
{
    public static BestStatsManager Instance;

    [Header("Pontuações")]
    public TextMeshProUGUI[] scoreLabels; // arraste os 5 textos no Inspector

    [Header("Tempos")]
    public TextMeshProUGUI[] timeLabels; // arraste os 5 textos no Inspector

    [Header("Totais")]
    public TextMeshProUGUI totalHitsLabel;
    public TextMeshProUGUI totalErrorsLabel;
    public TextMeshProUGUI percentageLabel;

    private List<int> highScores = new List<int>();
    private List<int> bestTimes = new List<int>();

    private int totalHits = 0;
    private int totalErrors = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Registra os dados de uma partida (chamado no final de um nível).
    /// </summary>
    public void RegisterResult(int score, int timeInSeconds, int hits, int errors)
    {
        Debug.Log("Resultado registrado");
        Debug.Log($"score = {score}, tempo = {timeInSeconds}, acertos = {hits}, erros = {errors}");

        // Atualiza listas locais
        highScores.Add(score);
        highScores = highScores.OrderByDescending(s => s).Take(5).ToList();

        if (timeInSeconds > 0)
        {
            bestTimes.Add(timeInSeconds);
            bestTimes = bestTimes.OrderBy(t => t).Take(5).ToList();
        }

        // Atualiza totais
        totalHits += hits;
        totalErrors += errors;
    }

    /// Atualiza os textos na interface do popup.
    public void UpdateLabels()
    {
        for (int i = 0; i < scoreLabels.Length; i++)
        {
            scoreLabels[i].text = i < highScores.Count ? highScores[i].ToString() : "-";
        }

        for (int i = 0; i < timeLabels.Length; i++)
        {
            timeLabels[i].text = i < bestTimes.Count ? FormatTime(bestTimes[i]) : "--:--";
        }

        totalHitsLabel.text = totalHits.ToString();
        totalErrorsLabel.text = totalErrors.ToString();

        int total = totalHits + totalErrors;
        float percent = total > 0 ? (100f * totalHits) / total : 0f;
        percentageLabel.text = $"{percent:F1}%";
    }

    /// Exibe o popup de relatório.
    public void ShowReport(GameObject reportPopup)
    {
        UpdateLabels();
        reportPopup.SetActive(true);
    }

    private string FormatTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return $"{minutes:00}:{seconds:00}";
    }

    // ========== Integração com JSON ==========
    public void LoadData(GameData gameData)
    {
        highScores.Clear();
        bestTimes.Clear();

        // Carrega os melhores scores e tempos por fase
        foreach (var level in gameData.LevelInfosPhase)
        {
            if (level.highscore > 0)
                highScores.Add(level.highscore);

            if (level.best_time > 0 && level.best_time != int.MaxValue)
                bestTimes.Add(level.best_time);
        }

        highScores = highScores.OrderByDescending(s => s).Take(5).ToList();
        bestTimes = bestTimes.OrderBy(t => t).Take(5).ToList();

        // Agora carrega os totais do JSON
        totalHits = gameData.TotalHits;
        totalErrors = gameData.TotalErrors;
    }

    public void SetTotals(int hits, int errors)
    {
        totalHits += hits;
        totalErrors += errors;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.TotalHits = totalHits;
        gameData.TotalErrors = totalErrors;
    }
}
