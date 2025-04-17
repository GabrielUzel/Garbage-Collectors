using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {
    // public AudioSource musicSource; TODO: Adionar uma música para o menu
    public Sprite musicOff;
    public Sprite musicOn;
    public Button musicButton;
    
    private bool musicIsMuted = false; // TODO: Essa variável deverá ler algum arquivo de salvamento de configurações para persistir a config do usuário 

    public void toggleMusic() {
        musicIsMuted = !musicIsMuted;
        // musicSource.mute = musicIsMuted;
        musicButton.image.sprite = musicIsMuted ? musicOff : musicOn;
    }
}
