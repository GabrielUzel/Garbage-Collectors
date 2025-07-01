using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
  public Sprite[] backgrounds;
  public SpriteRenderer spriteRenderer;
  private int totalWaste;
  private int collectedWaste;
  public int levelId;

  public GameObject plasticBin;
  public GameObject glassBin;
  public GameObject paperBin;
  public GameObject metalBin;
  public GameObject organicBin;
  public GameObject nonRecyclableBin;

  public GameObject extraCharacter;
  public Sprite[] sprites;
  public SpriteRenderer spriteRendererExtra;
  private string selectedAvatar = "";
  private bool isABoy;

  private Dictionary<int, Vector3[]> levelPositions = new Dictionary<int, Vector3[]>();

  public void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.sprite = backgrounds[0];

    totalWaste = LoadLevelsInfo.Instance.GetTotalWaste();

    levelId = LoadLevelsInfo.Instance.GetLevelId();
    UpdateBackground(0);
    DefineTrashPositions(levelId);

    selectedAvatar = PlayerPrefs.GetString("selected_avatar", "");
    isABoy = selectedAvatar == "boy" ? false : true;
    DefineExtraCharacter();
  }

  public void Update()
  {
    collectedWaste = TrashCountManager.Instance.CorrectTrashCount;
    UpdateBackground(collectedWaste);

    if (levelId == 5)
    {
      Avatar.Instance.UpdateSprite(collectedWaste, isABoy, spriteRendererExtra); 
    }
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
      new Vector3(41.7f,  -13.1f, 1)
    };
    levelPositions[4] = new Vector3[]
    {
      new Vector3(-17.2f, -16.1f, 1),
      new Vector3(5.8f, -16.1f, 1),
      new Vector3(28.8f, -16.1f, 1),
      new Vector3(51.8f, -16.1f, 1),
      new Vector3(74.8f, -16.1f, 1),
      new Vector3(97.8f, -16.1f, 1)
    };
    levelPositions[5] = new Vector3[]
    {
      new Vector3(-88.9f, -51, 1),
      new Vector3(-52.9f, -51, 1),
      new Vector3(-16.9f,  -51, 1),
      new Vector3(19.1f,  -51, 1),
      new Vector3(55.1f, -51, 1),
      new Vector3(91.09f, -51, 1),
    };

    Vector3[] positions = levelPositions[levelId];

    switch (levelId)
    {
      case 2:
        organicBin.transform.position = positions[0];
        metalBin.transform.position = positions[1];
        plasticBin.transform.position = positions[2];
        paperBin.transform.position = positions[3];
        nonRecyclableBin.transform.position = positions[4];
        glassBin.transform.position = positions[5];
        break;

      case 3:
        nonRecyclableBin.transform.position = positions[0];
        paperBin.transform.position = positions[1];
        glassBin.transform.position = positions[2];
        organicBin.transform.position = positions[3];
        metalBin.transform.position = positions[4];
        plasticBin.transform.position = positions[5];
        break;

      case 4:
        paperBin.transform.position = positions[0];
        nonRecyclableBin.transform.position = positions[1];
        metalBin.transform.position = positions[2];
        glassBin.transform.position = positions[3];
        organicBin.transform.position = positions[4];
        plasticBin.transform.position = positions[5];
        break;

      case 5:
        metalBin.transform.position = positions[0];
        nonRecyclableBin.transform.position = positions[1];
        organicBin.transform.position = positions[2];
        glassBin.transform.position = positions[3];
        plasticBin.transform.position = positions[4];
        paperBin.transform.position = positions[5];

        metalBin.transform.localScale = new Vector3(2.8f, 2.8f, 0f);
        nonRecyclableBin.transform.localScale = new Vector3(2.8f, 2.8f, 0f);
        organicBin.transform.localScale = new Vector3(2.8f, 2.8f, 0f);
        glassBin.transform.localScale = new Vector3(2.8f, 2.8f, 0f);
        plasticBin.transform.localScale = new Vector3(2.8f, 2.8f, 0f);
        paperBin.transform.localScale = new Vector3(2.8f, 2.8f, 0f);
        break;

      default:
        plasticBin.transform.position = positions[0];
        glassBin.transform.position = positions[1];
        paperBin.transform.position = positions[2];
        metalBin.transform.position = positions[3];
        organicBin.transform.position = positions[4];
        nonRecyclableBin.transform.position = positions[5];
        break;
    }
  }

  void DefineExtraCharacter()
  {
    if (levelId == 5)
    {
      spriteRendererExtra.sprite = isABoy ? sprites[0] : sprites[1];
      Vector3 position = new Vector3(126.7f, -43.7f, 0);
      extraCharacter.transform.position = position;
    }
  }
}
