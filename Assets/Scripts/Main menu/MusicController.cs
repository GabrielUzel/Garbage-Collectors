using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Sprite musicOff;
    public Sprite musicOn;
    public Button musicButton;
    private bool isMuted = false;
    private const string musicPrefKey = "MusicMuted";

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
}
