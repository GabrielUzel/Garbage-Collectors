using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    private string tagWaste = "Waste";
    private int totalWaste = 30;

    public Sprite[] backgrounds; // 0 = sujo, 1 = médio, 2 = limpo
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = backgrounds[0]; // começa sujo
    }

    void Update()
    {
        GameObject[] wastes = GameObject.FindGameObjectsWithTag(tagWaste);
        UpdateBackground(wastes.Length);
    }

    void UpdateBackground(int currentWaste)
    {
        int percentage = (100 * currentWaste) / totalWaste;

        if (percentage <= 30)
        {
            sr.sprite = backgrounds[2]; // limpo
        }
        else if (percentage <= 60)
        {
            sr.sprite = backgrounds[1]; // médio
        }
        else
        {
            sr.sprite = backgrounds[0]; // sujo
        }
    }
}
