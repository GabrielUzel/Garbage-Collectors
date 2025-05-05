using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeAvatar : MonoBehaviour
{
    public Image meninaAcenando;
    public Image meninoAcenando;
    public Image meninoSelecionarImage;
    public Image meninaSelecionarImage;

    public GameObject meninoSelecionarBtn;
    public GameObject meninoSelecionadoBtn;
    public GameObject meninaSelecionarBtn;
    public GameObject meninaSelecionadoBtn;

    private float fadedOpacity = 0.8f;
    private float fullOpacity = 1f;

    public void SelectGirl()
    {
        SetImageOpacity(meninoSelecionarImage, fadedOpacity);
        SetImageOpacity(meninaSelecionarImage, fullOpacity);

        SetImageOpacity(meninoAcenando, fadedOpacity);
        SetImageOpacity(meninaAcenando, fullOpacity);

        meninoSelecionadoBtn.SetActive(false);
        meninoSelecionarBtn.SetActive(true);

        meninaSelecionadoBtn.SetActive(true);
        meninaSelecionarBtn.SetActive(false);
    }

    public void SelectBoy()
    {
        SetImageOpacity(meninoSelecionarImage, fullOpacity);
        SetImageOpacity(meninaSelecionarImage, fadedOpacity);

        SetImageOpacity(meninoAcenando, fullOpacity);
        SetImageOpacity(meninaAcenando, fadedOpacity);

        meninoSelecionadoBtn.SetActive(true);
        meninoSelecionarBtn.SetActive(false);

        meninaSelecionadoBtn.SetActive(false);
        meninaSelecionarBtn.SetActive(true);
    }

    void SetImageOpacity(Image img, float alpha)
{
    if (img != null)
    {
        Color color = img.color;
        color.a = alpha;
        img.color = color;
    }
    else
    {
        Debug.LogWarning("Tentando alterar opacidade de uma imagem que não foi atribuída.");
    }
}
}
