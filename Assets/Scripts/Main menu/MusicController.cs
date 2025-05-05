using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))] 
public class MusicController : MonoBehaviour {
    public Sprite musicOff;
    public Sprite musicOn;
    public Button musicButton;
    private bool musicIsMuted = false; // TODO: Essa variável deverá ler algum arquivo de salvamento de configurações para persistir a config do usuário 
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioSource audioSource;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = true;  
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void toggleMusic() {
        musicIsMuted = !musicIsMuted;
        
        audioSource.volume = musicIsMuted ? 0f : 1f;

        print(audioSource.volume);
        musicButton.image.sprite = musicIsMuted ? musicOff : musicOn;
    }
}
