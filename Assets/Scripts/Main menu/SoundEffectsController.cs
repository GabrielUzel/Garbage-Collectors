using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SFX
{
  public string name;
  public AudioClip soundEffect;
}

public class SoundEffectsController : MonoBehaviour
{
  public static SoundEffectsController Instance;
  public Sprite soundEffectsOff;
  public Sprite soundEffectsOn;
  private Button soundEffectsButton;
  private bool isMuted = false;
  private const string soundEffectsPrefKey = "SoundEffectsMuted";
  private AudioSource audioSource;
  public List<SFX> audioList;
  private Dictionary<string, AudioClip> sfxDictionary;

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      audioSource = gameObject.AddComponent<AudioSource>();
      sfxDictionary = new Dictionary<string, AudioClip>();

      foreach (var sfx in audioList)
      {
        if (!sfxDictionary.ContainsKey(sfx.name))
        {
          sfxDictionary.Add(sfx.name, sfx.soundEffect);
        }
      }

      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }

  void Start()
  {
    isMuted = PlayerPrefs.GetInt(soundEffectsPrefKey, 0) == 1;
    audioSource.mute = isMuted;
  }

  public void RegisterButton(Button button)
  {
    soundEffectsButton = button;
    updateUI(isMuted);
  }

  public void updateUI(bool isMuted)
  {
    if (soundEffectsButton != null)
    {
      soundEffectsButton.image.sprite = isMuted ? soundEffectsOff : soundEffectsOn;
    }
  }

  public void toggleSoundEffects()
  {
    isMuted = !isMuted;
    audioSource.mute = isMuted;
    updateUI(isMuted);
    
    PlayerPrefs.SetInt(soundEffectsPrefKey, isMuted ? 1 : 0);
    PlayerPrefs.Save();
  }

  public void playSoundEffect(string name)
  {
    if (isMuted || !sfxDictionary.ContainsKey(name))
    {
      return;
    }

    AudioClip clip = sfxDictionary[name];
    audioSource.PlayOneShot(clip);
  }
}
