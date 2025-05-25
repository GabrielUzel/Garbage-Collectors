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

        var levelInfo = TrashCountManager.Instance.levelsInitialInfo.Find(
            l => l.levelId == TrashCountManager.Instance.PlayerCurrentLevel
        );

        if (levelInfo != null)
        {
            totalWaste = levelInfo.trashCount;
        }
        else
        {
            totalWaste = 1; 
        }
    }

    void Update()
    {
        collectedWaste = TrashCountManager.Instance.TrashCount;
        UpdateBackground(collectedWaste);
    }

    void UpdateBackground(int collected)
    {
        if (totalWaste <= 0) return;

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
