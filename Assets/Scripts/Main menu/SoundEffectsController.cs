using System;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Audio;

public class SoundEffectsController : MonoBehaviour 
{
    public Sprite soundEffectsOff;
    public Sprite soundEffectsOn;
    public Button soundEffectsButton;
    private bool isMuted = false;
    private const string soundEffectsPrefKey = "SoundEffectsMuted";

    public void updateUI(bool isMuted)
    {
        soundEffectsButton.image.sprite = isMuted ? soundEffectsOff : soundEffectsOn;
    }

    public void toggleSoundEffects()
    {
        isMuted = !isMuted;
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.setSFXMute(isMuted);
        if (LifeQuantityManager.Instance != null)
            LifeQuantityManager.Instance.setSFXMute(isMuted);
        updateUI(isMuted);

        //PlayerPrefs.SetInt(soundEffectsPrefKey, isMuted ? 1 : 0);
        //PlayerPrefs.Save();
    }
}
