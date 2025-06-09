using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource audioSrc;
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
        audioSrc.PlayOneShot(sound);
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Pontuação: {score}";
        }
    }

    public void toggleSoundEffect(bool mute)
    {
        audioSrc.mute = mute;
    }
}
