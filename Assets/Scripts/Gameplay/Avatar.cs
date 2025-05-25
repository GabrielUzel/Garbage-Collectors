using UnityEngine;

public class Avatar : MonoBehaviour
{
    private string tag = "Waste";
    private int totalScore;

    public GameObject scoreText;
    public Sprite[] sprites;
    private string selectedAvatar = "";
    private int score;
    private bool boy;
    private SpriteRenderer sr;

    private ScoreManager sm;

    void Awake()
    {
        selectedAvatar = PlayerPrefs.GetString("selected_avatar", "");
        boy = selectedAvatar == "boy"; 
    }

    void Start()
    {
        sm = scoreText.GetComponent<ScoreManager>();
        score = sm.score;

        GameObject[] wastes = GameObject.FindGameObjectsWithTag(tag);
        totalScore = wastes.Length * 200;
        ///
        sr = GetComponent<SpriteRenderer>();
        
        
        sr.sprite = boy ? sprites[0] : sprites[3];
    }   

    void Update()
    {
        score = sm.score;
        UpdateSprite(score);
    }
    
    void UpdateSprite(int score)
    {
        int scorePercentage = (100*score) / totalScore;

        if (scorePercentage >= 40 && scorePercentage < 60)
        {
            sr.sprite = boy ? sprites[1] : sprites[4];
        }
        else if (scorePercentage >= 70)
        {
            spriteRenderer.sprite = boy ? sprites[2] : sprites[5];
        }
    }
}
