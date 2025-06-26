using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
  public static MusicController Instance;
  public Sprite musicOff;
  public Sprite musicOn;
  public Button musicButton;
  private bool isMuted = false;
  private const string musicPrefKey = "MusicMuted";

  public void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }
  void Start()
  {
    isMuted = PlayerPrefs.GetInt(musicPrefKey, 0) == 1;
    updateUI(isMuted);
  }

  public void updateUI(bool isMuted)
  {
    musicButton.image.sprite = isMuted ? musicOff : musicOn;
  }

  public void toggleMusic()
  {
    isMuted = !isMuted;
    BackgroundMusic.Instance.SetMusicMute(isMuted);
    updateUI(isMuted);

    PlayerPrefs.SetInt(musicPrefKey, isMuted ? 1 : 0);
    PlayerPrefs.Save();
  }

  public void DecreaseMusicVolume()
  {
    BackgroundMusic.Instance.SetMusicVolume(0.3f);
  }

  public void IncreaseMusicVolume()
  {
    BackgroundMusic.Instance.SetMusicVolume(1f);
  }
}
