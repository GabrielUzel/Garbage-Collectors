using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsControllerLinker : MonoBehaviour
{
  void Start()
  {
    Button soundEffectsButton = GetComponent<Button>();
    SoundEffectsController.Instance.RegisterButton(soundEffectsButton);
    soundEffectsButton.onClick.RemoveAllListeners();
    soundEffectsButton.onClick.AddListener(() => SoundEffectsController.Instance.toggleSoundEffects());
  }
}