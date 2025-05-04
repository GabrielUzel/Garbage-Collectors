using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Wastes; 
    public int amount = 100000000;

    void Start()
    {
        GerarObjetos();
    }

    void GerarObjetos()
    {
        if (Wastes.Length == 0)
        {
            Debug.LogWarning("Nenhum prefab atribuído ao array 'Wastes'.");
            return;
        }

        int totalTypes = Wastes.Length;
        int baseAmount = amount / totalTypes;
        int extra = amount % totalTypes;

        for (int i = 0; i < totalTypes; i++)
        {
            int objectsToSpawn = baseAmount + (i < extra ? 1 : 0); // distribui resto
            for (int j = 0; j < objectsToSpawn; j++)
            {
                Vector2 randomPosition = GenerateRandomPosition();
                Instantiate(Wastes[i], randomPosition, Quaternion.identity);
            }
        }
    }

    Vector2 GenerateRandomPosition()
    {
        Vector2 screenPosition = new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height/2));
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
