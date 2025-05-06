using UnityEngine;
using UnityEngine.UI;

public class PainelInformacoes : MonoBehaviour
{
    [SerializeField] public Text Level;
    public Text Trash;
    public Text TimeText; // nome alterado aqui

    public void UpdatePanel(int level, int trash, float timeInSeconds)
    {
        Level.text = level.ToString();
        Trash.text = trash.ToString();

        int minutes = Mathf.FloorToInt(timeInSeconds  / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds  % 60f);
        TimeText.text = $"{minutes}:{seconds:00}"; // atualizado aqui também
    }

    void Start()
    {
        UpdatePanel(1, 20, 180); // Exemplo
    }
}
