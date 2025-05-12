using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;
    public Sprite musicOff;
    public Sprite musicOn;
    public Button musicButton;

    private bool musicIsMuted = false;
    private const string musicPrefKey = "MusicMuted";

    public void getMusicState()
    {
        musicIsMuted = PlayerPrefs.GetInt(musicPrefKey, 0) == 1;

        musicSource.mute = musicIsMuted;
        musicButton.image.sprite = musicIsMuted ? musicOff : musicOn;
    }

    public void toggleMusic() 
    {
        musicIsMuted = !musicIsMuted;
        musicSource.mute = musicIsMuted;
        musicButton.image.sprite = musicIsMuted ? musicOff : musicOn;
        
        PlayerPrefs.SetInt(musicPrefKey, musicIsMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}
