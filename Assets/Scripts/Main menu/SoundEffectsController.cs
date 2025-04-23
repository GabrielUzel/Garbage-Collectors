using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Audio;

public class SoundEffectsController : MonoBehaviour {
    // public AudioMixer soundEffectsSource; // TODO: Adionar uma música para o menu
    public Sprite soundEffectsOff;
    public Sprite soundEffectsOn;
    public Button soundEffectsButton;
    
    private bool isMuted = false; // TODO: Essa variável deverá ler algum arquivo de salvamento de configurações para persistir a config do usuário 

    public void toggleSoundEffects() {
        isMuted = !isMuted;
        // soundEffectsSource.SetFloat("SFXVolume", isSfxMuted ? -80f : 0f);
        soundEffectsButton.image.sprite = isMuted ? soundEffectsOff : soundEffectsOn;
    }
}
