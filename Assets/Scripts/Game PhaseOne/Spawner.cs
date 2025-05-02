using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] plasticWastes; // array com todos os prefabs
    public int amount = 100000000; // número total de objetos a gerar

    void Start()
    {
        GerarObjetos();
    }

    void GerarObjetos()
    {
        if (plasticWastes.Length == 0)
        {
            Debug.LogWarning("Nenhum prefab atribuído ao array 'plasticWastes'.");
            return;
        }

        int totalTypes = plasticWastes.Length;
        int baseAmount = amount / totalTypes;
        int extra = amount % totalTypes;

        for (int i = 0; i < totalTypes; i++)
        {
            int objectsToSpawn = baseAmount + (i < extra ? 1 : 0); // distribui resto
            for (int j = 0; j < objectsToSpawn; j++)
            {
                Vector2 randomPosition = GenerateRandomPosition();
                Instantiate(plasticWastes[i], randomPosition, Quaternion.identity);
            }
        }
    }

    Vector2 GenerateRandomPosition()
    {
        Vector2 screenPosition = new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height));
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
