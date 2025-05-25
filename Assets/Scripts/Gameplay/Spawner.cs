using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Wastes;
    public int amount;

    public RectTransform spawnArea1;
    public RectTransform spawnArea2;

    void Start()
    {
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
}
