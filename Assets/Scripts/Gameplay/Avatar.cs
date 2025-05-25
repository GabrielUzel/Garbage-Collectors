using UnityEngine;

public class Avatar : MonoBehaviour
{
    private readonly string wasteTag = "Waste";
    private readonly int totalWaste = 30;
    public Sprite[] sprites;
    private string selectedAvatar = "";
    private bool boy;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        selectedAvatar = PlayerPrefs.GetString("selected_avatar", "");
        boy = selectedAvatar == "boy"; 
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = boy ? sprites[0] : sprites[3];
    }   

    void Update()
    {
        GameObject[] wastes = GameObject.FindGameObjectsWithTag(wasteTag);
        UpdateSprite(wastes.Length);
    }
    
    void UpdateSprite(int wasteAmount)
    {
        int wastePercentage = 100 * wasteAmount / totalWaste;

        if (wastePercentage <= 30)
        {
            spriteRenderer.sprite = boy ? sprites[2] : sprites[5];
        }
        else if (wastePercentage <= 60)
        {
            spriteRenderer.sprite = boy ? sprites[1] : sprites[4];
        }
    }
}
