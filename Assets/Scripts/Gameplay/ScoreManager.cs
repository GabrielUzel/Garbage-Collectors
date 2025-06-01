using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public AudioClip som;           
    private AudioSource audioSrc;
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
        audioSrc = GetComponent<AudioSource>();

        if (audioSrc == null)
            audioSrc = gameObject.AddComponent<AudioSource>();
        UpdateScoreText();
    }

    public void AddScore()
    {
        score += 200;
        UpdateScoreText();
        audioSrc.PlayOneShot(som);
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Pontuação: {score}";
        }
    }
}
