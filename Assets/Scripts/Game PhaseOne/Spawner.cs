using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject PlasticWaste;
    public int amount;

    void Start()
    {
        GerarObjetos();
    }
    void Update()
    {

    }

    void GerarObjetos()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2 randomPosition = GenerateRandomPosition();
            Instantiate(PlasticWaste, randomPosition, Quaternion.identity);
        }
    }

    Vector2 GenerateRandomPosition()
    {
        Vector2 screenPosition = new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height));
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}

