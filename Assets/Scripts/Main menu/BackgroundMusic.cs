using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
  public static BackgroundMusic Instance;
  public AudioSource musicSource;

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

    bool savedState = PlayerPrefs.GetInt("MusicMuted") == 1;
    musicSource.mute = savedState;
  }

  public void SetMusicMute(bool mute)
  {
    musicSource.mute = mute;
  }

  public void SetMusicVolume(float volume)
  {
    musicSource.volume = volume; 
  }
}
