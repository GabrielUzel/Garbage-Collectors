using UnityEngine;

public class Avatar : MonoBehaviour
{
    private int totalWaste;
    private int collectedWaste;

    public Sprite[] sprites;
    private string selectedAvatar = "";
    private bool isBoy;
    public SpriteRenderer spriteRenderer;

    public void Awake()
    {
        selectedAvatar = PlayerPrefs.GetString("selected_avatar", "");
        isBoy = selectedAvatar == "boy";
    }

    public void Start()
    {
        totalWaste = LoadLevelsInfo.Instance.GetTotalWaste();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = isBoy ? sprites[0] : sprites[3];
    }

    public void Update()
    {
        collectedWaste = TrashCountManager.Instance.CorrectTrashCount;
        UpdateSprite(collectedWaste);
    }

    void UpdateSprite(int collected)
    {
        if (totalWaste <= 0)
        {
            return;            
        }

        int percentage = 100 * collected / totalWaste;

        if (percentage >= 100)
        {
            spriteRenderer.sprite = isBoy ? sprites[2] : sprites[5];
        }
        else if (percentage >= 60)
        {
            spriteRenderer.sprite = isBoy ? sprites[1] : sprites[4];
        }
    }
}
