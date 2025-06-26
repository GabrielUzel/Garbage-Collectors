using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
  private int totalWaste;
  private int collectedWaste;
  private int levelId;

  public Sprite[] sprites;
  private string selectedAvatar = "";
  private bool isBoy;
  public SpriteRenderer spriteRenderer;

  public GameObject avatar;
  private Dictionary<int, Vector3> levelPositions = new Dictionary<int, Vector3>();

  public void Awake()
  {
    selectedAvatar = PlayerPrefs.GetString("selected_avatar", "");
    isBoy = selectedAvatar == "boy";
  }

  public void Start()
  {
    totalWaste = LoadLevelsInfo.Instance.GetTotalWaste();
    levelId = LoadLevelsInfo.Instance.GetLevelId();

    spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.sprite = isBoy ? sprites[0] : sprites[3];
    DefineAvatarPosition(levelId);
  }

  public void Update()
  {
    collectedWaste = TrashCountManager.Instance.CorrectTrashCount;
    UpdateSprite(collectedWaste);
  }

  void UpdateSprite(int collected)
  {
    if (totalWaste <= 0)
    {
      return;
    }

    int percentage = 100 * collected / totalWaste;

    if (percentage >= 100)
    {
      spriteRenderer.sprite = isBoy ? sprites[2] : sprites[5];
    }
    else if (percentage >= 60)
    {
      spriteRenderer.sprite = isBoy ? sprites[1] : sprites[4];
    }
  }

  void DefineAvatarPosition(int levelId)
  {
    levelPositions[1] = new Vector3(124f, -22.3f, 0);
    levelPositions[2] = new Vector3(-86f, -29.3f, 0);
    levelPositions[3] = new Vector3(69.5f, 0.1f, 0);
    levelPositions[4] = new Vector3(-115.1f, -45.9f, 0);
    levelPositions[5] = new Vector3(-111.8f, -43.7f, 0);
    Vector3 position = levelPositions[levelId];
    avatar.transform.position = position;
  }
}
