using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  public static ScoreManager Instance;
  public int score = 0;
  [SerializeField] TextMeshProUGUI scoreText;

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

  public void AddScore()
  {
    score += 200;
    UpdateScoreText();
    SoundEffectsController.Instance.playSoundEffect("addScore");
  }

  private void UpdateScoreText()
  {
    if (scoreText != null)
    {
      scoreText.text = $"Pontuação: {score}";
    }
  }
}
