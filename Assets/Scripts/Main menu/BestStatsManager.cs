using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class BestStatsManager : MonoBehaviour
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

    // Registra os dados de uma partida (chamado no final de um nível).
    public void RegisterResult(int score, int timeInSeconds, int hits, int errors)
    {
        Debug.Log("Resultado registrado");
        Debug.Log("\nscore =" + score);
        Debug.Log("\ntimeInSeconds = " + timeInSeconds);
        Debug.Log("\nhits= " + hits);
        Debug.Log("\nerrors = " + errors);

        // Adiciona e organiza os scores
        highScores.Add(score);
        highScores = highScores.OrderByDescending(s => s).Take(5).ToList();

        // Adiciona e organiza os tempos
        if (timeInSeconds > 0)
        {
            bestTimes.Add(timeInSeconds);
            bestTimes = bestTimes.OrderBy(t => t).Take(5).ToList();
        }

        // Soma os totais
        totalHits += hits;
        totalErrors += errors;

        // 🔐 Salva os últimos resultados no PlayerPrefs
        PlayerPrefs.SetInt("UltimaPontuacao", score);
        PlayerPrefs.SetInt("UltimoTempo", timeInSeconds);
        PlayerPrefs.SetInt("UltimosAcertos", hits);
        PlayerPrefs.SetInt("UltimosErros", errors);
        PlayerPrefs.Save();
    }

    /// Atualiza as labels da tela de estatísticas.
    public void UpdateLabels()
    {
        // Pontuações
        for (int i = 0; i < scoreLabels.Length; i++)
        {
            scoreLabels[i].text = i < highScores.Count ? highScores[i].ToString() : "-";
        }

        // Tempos formatados
        for (int i = 0; i < timeLabels.Length; i++)
        {
            timeLabels[i].text = i < bestTimes.Count ? FormatTime(bestTimes[i]) : "--:--";
        }

        // Totais e porcentagem
        totalHitsLabel.text = totalHits.ToString();
        totalErrorsLabel.text = totalErrors.ToString();

        int total = totalHits + totalErrors;
        float percent = total > 0 ? (100f * totalHits) / total : 0f;
        percentageLabel.text = $"{percent:F1}%";

        CarregarUltimosDados();
    }

    /// Exibe o painel de relatório (se você quiser fazer isso aqui).
    public void ShowReport(GameObject reportPopup)
    {
        CarregarUltimosDados();
        UpdateLabels();
        reportPopup.SetActive(true);
    }

    private string FormatTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return $"{minutes:00}:{seconds:00}";

    }
    
    public void CarregarUltimosDados()
{
    if (PlayerPrefs.HasKey("UltimaPontuacao"))
    {
        int score = PlayerPrefs.GetInt("UltimaPontuacao");
        int tempo = PlayerPrefs.GetInt("UltimoTempo");
        int acertos = PlayerPrefs.GetInt("UltimosAcertos");
        int erros = PlayerPrefs.GetInt("UltimosErros");

        // Reinsere nos dados internos
        highScores.Add(score);
        highScores = highScores.OrderByDescending(s => s).Take(5).ToList();

        bestTimes.Add(tempo);
        bestTimes = bestTimes.OrderBy(t => t).Take(5).ToList();

        totalHits += acertos;
        totalErrors += erros;
    }
}

}