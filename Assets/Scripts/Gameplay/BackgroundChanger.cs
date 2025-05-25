using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    public Sprite[] backgrounds; 
    private SpriteRenderer sr;

    private int totalWaste;
    private int collectedWaste;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = backgrounds[0]; 

        var levelInfo = TrashCountManager.Instance.levelsInitialInfo.Find(
            l => l.levelId == TrashCountManager.Instance.PlayerCurrentLevel
        );

        if (levelInfo != null)
        {
            totalWaste = levelInfo.trashCount;
        }
        else
        {
            Debug.LogWarning("Level info não encontrado!");
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

        int percentage = (100 * collected) / totalWaste;

        if (percentage >= 100)
        {
            sr.sprite = backgrounds[2]; 
        }
        else if (percentage >= 60)
        {
            sr.sprite = backgrounds[1]; 
        }
        else
        {
            sr.sprite = backgrounds[0]; 
        }
    }
}
