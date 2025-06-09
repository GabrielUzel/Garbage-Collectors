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

    public void Start()
    {
        getSoundEffectsState();
    }

    public void getSoundEffectsState()
    {
        isMuted = PlayerPrefs.GetInt(soundEffectsPrefKey, 0) == 1;

        soundEffectsButton.image.sprite = isMuted ? soundEffectsOff : soundEffectsOn;
    }

    public void toggleSoundEffects()
    {
        isMuted = !isMuted;

        soundEffectsButton.image.sprite = isMuted ? soundEffectsOff : soundEffectsOn;
        try
        {
            LifeQuantityManager.Instance.toggleSoundEffect(isMuted);
            ScoreManager.Instance.toggleSoundEffect(isMuted);
        }
        catch (NullReferenceException exception)
        {
            //Está aqui por que dá erro desativar sons pelo menu
            //não está salvando nas preferencias para outras cenas
        }
        
    }
}
