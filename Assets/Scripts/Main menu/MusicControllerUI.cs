using UnityEngine;
using UnityEngine.UI;

public class MusicControllerUI : MonoBehaviour
{
  public Sprite musicOff;
  public Sprite musicOn;
  public Button musicButton;

  void Start()
  {
    UpdateUI();
  }

  public void ToggleMusic()
  {
    MusicController.Instance.ToggleMusic();
    UpdateUI();
  }

  private void UpdateUI()
  {
    musicButton.image.sprite = MusicController.Instance.GetIsMuted() ? musicOff : musicOn;
  }
}
