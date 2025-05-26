using UnityEngine;

public class Avatar : MonoBehaviour
{
    public GameObject scoreText;
    public Sprite[] sprites;
    private string selectedAvatar = "";
    private int totalScore;
    private int score;
    private bool isBoy;
    public SpriteRenderer spriteRenderer;

    public void Awake()
    {
        selectedAvatar = PlayerPrefs.GetString("selected_avatar", "");
        isBoy = selectedAvatar == "boy"; 
    }

    public void Start()
    {
        GameObject[] wastes = GameObject.FindGameObjectsWithTag("Waste");
        totalScore = wastes.Length * 200;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = isBoy ? sprites[0] : sprites[3];
    }

    public void Update()
    {
        score = ScoreManager.Instance.score;
        UpdateSprite(score);
    }
    
    void UpdateSprite(int score)
    {
        int scorePercentage = 100 * score / totalScore;

        if (scorePercentage >= 40 && scorePercentage < 60)
        {
            spriteRenderer.sprite = isBoy ? sprites[1] : sprites[4];
        }
        else if (scorePercentage >= 70)
        {
            spriteRenderer.sprite = isBoy ? sprites[2] : sprites[5];
        }
    }
}
