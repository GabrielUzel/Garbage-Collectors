using UnityEngine;
using UnityEngine.UI;

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

        LoadMusicState();
    }

    public void SetMusicMute(bool mute)
    {
        musicSource.mute = mute;
    }

    private void LoadMusicState()
    {
        bool savedState = PlayerPrefs.GetInt("MusicMuted") == 1;
        musicSource.mute = savedState;
    }
}
