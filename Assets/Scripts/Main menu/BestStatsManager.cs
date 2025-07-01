using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class BestStatsManager : MonoBehaviour, IDataPersistence
{
  public static BestStatsManager Instance;

  [Header("Pontuações")]
  public TextMeshProUGUI[] scoreLabels; 

  [Header("Tempos")]
  public TextMeshProUGUI[] timeLabels; 

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
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }

  public void UpdateLabels()
  {
    for (int i = 0; i < scoreLabels.Length; i++)
    {
      scoreLabels[i].text = i < highScores.Count && highScores[i] > 0 ? highScores[i].ToString() : "-";
    }

    for (int i = 0; i < timeLabels.Length; i++)
    {
      if (i < bestTimes.Count && bestTimes[i] != int.MaxValue)
      {
        timeLabels[i].text = FormatTime(bestTimes[i]);
      }
      else
      {
        timeLabels[i].text = "--:--";
      }
    }

    totalHitsLabel.text = totalHits.ToString();
    totalErrorsLabel.text = totalErrors.ToString();

    int total = totalHits + totalErrors;
    float percent = total > 0 ? 100f * totalHits / total : 0f;
    percentageLabel.text = $"{percent:F1}%";
  }

  private string FormatTime(int totalSeconds)
  {
    int minutes = totalSeconds / 60;
    int seconds = totalSeconds % 60;
    return $"{minutes:00}:{seconds:00}";
  }

  public void LoadData(GameData gameData)
  {
    highScores = Enumerable.Repeat(0, 5).ToList();
    bestTimes = Enumerable.Repeat(int.MaxValue, 5).ToList();

    foreach (var level in gameData.LevelInfosPhase)
    {
      int index = level.id - 1; 

      if (index >= 0 && index < 5)
      {
        highScores[index] = level.highscore;
        bestTimes[index] = level.best_time;
      }
    }

    totalHits = gameData.TotalHits;
    totalErrors = gameData.TotalErrors;
  }

  public void SaveData(ref GameData gameData)
  {
    gameData.TotalHits = totalHits;
    gameData.TotalErrors = totalErrors;
  }
}
