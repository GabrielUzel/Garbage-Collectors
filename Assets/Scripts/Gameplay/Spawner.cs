using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int amount;
    public GameObject[] Wastes;
    public RectTransform spawnArea1;
    public RectTransform spawnArea2;
    public RectTransform[] spawnAreas;
    public int levelId;

    void Start()
    {
        levelId = LoadLevelsInfo.Instance.GetLevelId(); 
        int trashes = LoadLevelsInfo.Instance.GetTotalWaste();
        int lifes = LoadLevelsInfo.Instance.GetLifes();
        spawnAreas = LoadSpawnerPosition(levelId,spawnArea1,spawnArea2);
        spawnArea1= spawnAreas[0];
        spawnArea2 = spawnAreas[1];
        amount = trashes + lifes - 1;
        GenerateWastes();
    }

    void GenerateWastes()
    {
        int totalTypes = Wastes.Length;
        int baseAmount = amount / totalTypes;
        int extra = amount % totalTypes;

        for (int i = 0; i < totalTypes; i++)
        {
            int objectsToSpawn = baseAmount + (i < extra ? 1 : 0);
            for (int j = 0; j < objectsToSpawn; j++)
            {
                RectTransform chosenArea = Random.value < 0.7f ? spawnArea1 : spawnArea2;
                Vector2 spawnPos = GetRandomPositionInRect(chosenArea);
                Instantiate(Wastes[i], spawnPos, Quaternion.identity);
            }
        }
    }

    Vector2 GetRandomPositionInRect(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        float minX = corners[0].x;
        float maxX = corners[2].x;
        float minY = corners[0].y;
        float maxY = corners[2].y;

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        return new Vector2(x, y);
    }

    RectTransform[] LoadSpawnerPosition(int levelId, RectTransform spawnArea1, RectTransform spawnArea2)
    {
        RectTransform[] spawnAreas = new RectTransform[2];
        switch (levelId)
        {
            case 2:
                spawnArea1.sizeDelta = new Vector2(76.2829f, 61.9259f);  // largura x altura
                spawnArea1.anchoredPosition = new Vector2(-34.7353f, -46.75049f);  // posição relativa ao pai
                spawnArea2.sizeDelta = new Vector2(135.0627f, 18.8284f);  // largura x altura
                spawnArea2.anchoredPosition = new Vector2(69.56264f, -66.12321f);  // posição relativa ao pai
                break;

            case 3:
                spawnArea1.sizeDelta = new Vector2(143.7364f, 48.9865f);  // largura x altura
                spawnArea1.anchoredPosition = new Vector2(-36.285f, -53.43248f);  // posição relativa ao pai
                spawnArea2.sizeDelta = new Vector2(73.4686f, -49.0161f);  // largura x altura
                spawnArea2.anchoredPosition = new Vector2(72.27163f, -52.86079f);  // posição relativa ao pai
                break;


            case 4:
                spawnArea1.sizeDelta = new Vector2(169.2049f, 34.3796f);  // largura x altura
                spawnArea1.anchoredPosition = new Vector2(-13.06369f, -60.7359f);  // posição relativa ao pai
                spawnArea2.sizeDelta = new Vector2(68.0688f, -48.6743f );  // largura x altura
                spawnArea2.anchoredPosition = new Vector2(106.3168f,-52.86649f);  // posição relativa ao pai
                break;


            case 5:
                spawnArea1.sizeDelta = new Vector2(148.595f, 24.6938f);  // largura x altura
                spawnArea1.anchoredPosition = new Vector2(-23.7536f, -15.3464f);  // posição relativa ao pai
                spawnArea2.sizeDelta = new Vector2(86.8297f, -16.6258f);  // largura x altura
                spawnArea2.anchoredPosition = new Vector2(98.76106f, -18f);  // posição relativa ao pai
                break;


            default:
                spawnArea1.sizeDelta = new Vector2(270.097f, 24.8308f);  // largura x altura
                spawnArea1.anchoredPosition = new Vector2(-0.0515f, -62.9618f);  // posição relativa ao pai
                spawnArea2.sizeDelta = new Vector2(54.4689f, 11.5151f);  // largura x altura
                spawnArea2.anchoredPosition = new Vector2(56.6356f, -27.1f);  // posição relativa ao pai
                break;

        }
        spawnAreas[0] = spawnArea1;
        spawnAreas[1] = spawnArea2;
        return spawnAreas;
    }
}
