using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore()
    {
        score += 200;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        Debug.Log(scoreText.text);
        if (scoreText != null)
        {
            scoreText.text = $"Pontuação: {score}";
        }
    }
    //talvez adicionar aq caso o usuário chegue na maior pontuação possivel antes de finalizar o jogo, dai ele ganha
}
