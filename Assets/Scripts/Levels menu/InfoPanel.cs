using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public static InfoPanel Instance;
    [SerializeField] public Text LevelText;
    public Text TrashText;
    public Text TimeText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdatePanel(int level, int trash, float timeInSeconds)
    {
        LevelText.text = level.ToString();
        TrashText.text = trash.ToString();

        int minutes = Mathf.FloorToInt(timeInSeconds  / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds  % 60f);
        TimeText.text = $"{minutes}:{seconds:00}";
    }
}
