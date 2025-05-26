using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;
    public Sprite musicOff;
    public Sprite musicOn;
    public Button musicButton;
    private bool isMuted = false;
    private const string musicPrefKey = "MusicMuted";

    public void Start()
    {
        getMusicState();
    }

    public void getMusicState()
    {
        isMuted = PlayerPrefs.GetInt(musicPrefKey, 0) == 1;

        musicSource.mute = isMuted;
        musicButton.image.sprite = isMuted ? musicOff : musicOn;
    }

    public void toggleMusic() 
    {
        isMuted = !isMuted;
        musicSource.mute = isMuted;
        musicButton.image.sprite = isMuted ? musicOff : musicOn;
        
        PlayerPrefs.SetInt(musicPrefKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}
