using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    public Sprite[] backgrounds;
    private SpriteRenderer spriteRenderer;
    private int totalWaste;
    private int collectedWaste;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = backgrounds[0];

        totalWaste = LoadLevelsInfo.Instance.GetTotalWaste();
    }

    void Update()
    {
        collectedWaste = TrashCountManager.Instance.CorrectTrashCount;
        UpdateBackground(collectedWaste);
    }

    void UpdateBackground(int collected)
    {
        if (totalWaste <= 0)
        {
            return;            
        }

        int percentage = 100 * collected / totalWaste;

        if (percentage >= 100)
        {
            spriteRenderer.sprite = backgrounds[2];
        }
        else if (percentage >= 60)
        {
            spriteRenderer.sprite = backgrounds[1];
        }
        else
        {
            spriteRenderer.sprite = backgrounds[0];
        }
    }
}
