using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Audio;

public class SoundEffectsController : MonoBehaviour 
{
    // public AudioMixer soundEffectsSource; // TODO: Adicionar efeitos sonoros ao mixer de áudio
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

        // soundEffectsSource.mute = isMuted; // TODO: Mudar a forma de mutar os efeitos sonoros
        soundEffectsButton.image.sprite = isMuted ? soundEffectsOff : soundEffectsOn;
    }

    public void toggleSoundEffects()
    {
        isMuted = !isMuted;
        // soundEffectsSource.SetFloat("SFXVolume", isSfxMuted ? -80f : 0f); // TODO: Mudar a forma de desmutar os efeitos sonoros
        soundEffectsButton.image.sprite = isMuted ? soundEffectsOff : soundEffectsOn;
    }
}
