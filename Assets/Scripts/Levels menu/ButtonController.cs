using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IDataPersistence
{
  public int PlayerCurrentLevel;
  public Button LevelOne;
  public Button LevelTwo;
  public Button LevelThree;
  public Button LevelFour;
  public Button LevelFive;
  public Image ImageButtonTwo;
  public Image ImageButtonThree;
  public Image ImageButtonFour;
  public Image ImageButtonFive;

  public void Start()
  {
    ImageButtonTwo = LevelTwo.GetComponent<Image>();
    ImageButtonThree = LevelThree.GetComponent<Image>();
    ImageButtonFour = LevelFour.GetComponent<Image>();
    ImageButtonFive = LevelFive.GetComponent<Image>();

    LevelTwo.interactable = false;
    LevelThree.interactable = false;
    LevelFour.interactable = false;
    LevelFive.interactable = false;

    if (PlayerCurrentLevel >= 2)
    {
      LevelTwo.interactable = true;
      ImageButtonTwo.color = new Color(1f, 1f, 1f, 0f);
    }
    if (PlayerCurrentLevel >= 3)
    {
      LevelThree.interactable = true;
      ImageButtonThree.color = new Color(1f, 1f, 1f, 0f);
    }
    if (PlayerCurrentLevel >= 4)
    {
      LevelFour.interactable = true;
      ImageButtonFour.color = new Color(1f, 1f, 1f, 0f);
    }
    if (PlayerCurrentLevel >= 5)
    {
      LevelFive.interactable = true;
      ImageButtonFive.color = new Color(1f, 1f, 1f, 0f);
    }
  }

  public void LoadData(GameData gameData)
  {
    PlayerCurrentLevel = gameData.PlayerCurrentLevel;
  }

  public void SaveData(ref GameData gameData)
  {
    // Empty implementation
  }
}
