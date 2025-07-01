using UnityEngine;

public class MusicController : MonoBehaviour
{
  public static MusicController Instance;
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
  }

  public void ToggleMusic()
  {
    isMuted = !isMuted;
    BackgroundMusic.Instance.SetMusicMute(isMuted);

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

  public bool GetIsMuted()
  {
    return isMuted;
  }
}
