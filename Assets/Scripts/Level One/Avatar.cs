using UnityEngine;

public class Avatar : MonoBehaviour
{
    private string tag = "Waste";
    private int totalWaste = 30;
    public Sprite[] sprites;
    private string selectedAvatar = "";
    private bool boy;
    private SpriteRenderer sr;

    void Awake()
    {
        selectedAvatar = PlayerPrefs.GetString("selected_avatar", "");

        boy = selectedAvatar == "boy"; 
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        sr.sprite = boy ? sprites[0] : sprites[3];
    }   

    void Update()
    {
        GameObject[] wastes = GameObject.FindGameObjectsWithTag(tag);
        UpdateSprite(wastes.Length);
    }
    
    void UpdateSprite(int wasteAmount)
    {
        int wastePercentage = (100*wasteAmount) / totalWaste;

        if (wastePercentage <= 30)
        {
            sr.sprite = boy ? sprites[2] : sprites[5];
        }
        else if (wastePercentage <= 60)
        {
            sr.sprite = boy ? sprites[1] : sprites[4];
        }
    }
}
