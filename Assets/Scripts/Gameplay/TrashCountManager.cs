using UnityEngine;

public class TrashCountManager : MonoBehaviour
{
  public static TrashCountManager Instance;
  public int CorrectTrashCount = 0;
  public int IncorrectTrashCount = 0;
  public GameData GameData;
  private int trashes;
  private int lifes;
  private int totalTrashes;

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }

  void Start()
  {
    trashes = LoadLevelsInfo.Instance.GetTotalWaste();
    lifes = LoadLevelsInfo.Instance.GetLifes();
    totalTrashes = trashes + lifes - 1;
    MusicController.Instance.DecreaseMusicVolume();
  }

  void Update()
  {
    if (CorrectTrashCount + IncorrectTrashCount == totalTrashes)
    {
      TimeManager.Instance.timerIsRunning = false;
      LevelResult.Instance.ShowPopUp("Victory");
    }
  }

  public void AddCorrectTrashCount()
  {
    CorrectTrashCount++;

    if (VerifyIfPlayerWon())
    {
      LevelResult.Instance.victory = true;
    }
  }

  public void AddIncorrectTrashCount()
  {
    IncorrectTrashCount++;
  }

    public bool VerifyIfPlayerWon()
    {
        
        if (CorrectTrashCount >= trashes)
        {
            return true;
        }

    return false;
  }

  public void CleanAllTrashes()
  {
    GameObject[] wastes = GameObject.FindGameObjectsWithTag("Waste");

    foreach (GameObject waste in wastes)
    {
      Destroy(waste);
    }
  }
}
