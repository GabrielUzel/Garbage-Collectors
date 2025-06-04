using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    public Sprite[] backgrounds;
    private SpriteRenderer spriteRenderer;
    private int totalWaste;
    private int collectedWaste;
    public int levelId;

    public GameObject plasticBin;
    public GameObject glassBin;
    public GameObject paperBin;
    public GameObject metalBin;
    public GameObject organicBin;
    public GameObject nonRecyclableBin;

    private Dictionary<int, Vector3[]> levelPositions = new Dictionary<int, Vector3[]>();

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = backgrounds[0];

        totalWaste = LoadLevelsInfo.Instance.GetTotalWaste();

        levelId = LoadLevelsInfo.Instance.GetLevelId(); 
        UpdateBackground(0);
        DefineTrashPositions(levelId);
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
        int indexOffset = (levelId - 1) * 3; 


        if (percentage >= 100)
        {
            spriteRenderer.sprite = backgrounds[indexOffset + 2];
        }
        else if (percentage >= 60)
        {
            spriteRenderer.sprite = backgrounds[indexOffset + 1];
        }
        else
        {
            spriteRenderer.sprite = backgrounds[indexOffset + 0];

        }
    }

    void DefineTrashPositions(int levelId)
    {
        
        levelPositions[1] = new Vector3[]
        {
            new Vector3(-120f, -35f, 1), 
            new Vector3(-95f, -35f, 1),
            new Vector3(-70f, -35f, 1),
            new Vector3(-45f, -35f, 1),
            new Vector3(-20f, -35f, 1),
            new Vector3(5f, -35f, 1),

        };
        levelPositions[2] = new Vector3[]
               {
            new Vector3(15.6f, -40f, 1),
            new Vector3(38.6f, -40f, 1),
            new Vector3(61.6f, -40f, 1),
            new Vector3(84.6f, -40f, 1),
            new Vector3(107.6f, -40f, 1),
            new Vector3(130.6f, -40f, 1)

        };

        levelPositions[3] = new Vector3[]
       {
            new Vector3(-73.3f, -13.1f, 1),
            new Vector3(-50.3f, -13.1f, 1),
            new Vector3(-27.3f, -13.1f, 1),
            new Vector3(-4.3f,  -13.1f, 1),
            new Vector3(18.7f,  -13.1f, 1),
            new Vector3(41.7f,  -13.1f, 1),

       };


        levelPositions[4] = new Vector3[]
       {
            new Vector3(-17.2f, -16.1f, 1),
            new Vector3(5.8f, -16.1f, 1),
            new Vector3(28.8f, -16.1f, 1),
            new Vector3(51.8f, -16.1f, 1),
            new Vector3(74.8f, -16.1f, 1),
            new Vector3(97.8f, -16.1f, 1),

       };

        levelPositions[5] = new Vector3[]
       {
            new Vector3(-62.1f, -57.2f, 1),
            new Vector3(-39.1f, -57.2f, 1),
            new Vector3(-16.1f, -57.2f, 1),
            new Vector3(6.9f, -57.2f, 1),
            new Vector3(29.9f, -57.2f, 1),
            new Vector3(52.9f, -57.2f, 1),

       };

        Vector3[] positions = levelPositions[levelId];
        plasticBin.transform.position = positions[0];
        glassBin.transform. position = positions[1];
        paperBin.transform.position = positions[2];
        metalBin.transform.position = positions[3];
        organicBin.transform.position = positions[4];
        nonRecyclableBin.transform.position = positions[5];

    }
}
