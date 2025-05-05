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

    private string avatarSelecionado = "";

    void Start()
    {
        // Pegamos o avatar salvo, se existir
        avatarSelecionado = PlayerPrefs.GetString("avatarSelecionado", "");

        if (avatarSelecionado == "menino")
        {
            AplicarSelecaoMenino();
        }
        else if (avatarSelecionado == "menina")
        {
            AplicarSelecaoMenina();
        }
        else
        {
            // Nenhum avatar selecionado: mostrar estado neutro
            SetImageOpacity(meninoAcenando, fullOpacity);
            SetImageOpacity(meninaAcenando, fullOpacity);

            meninoSelecionadoBtn.SetActive(false);
            meninoSelecionarBtn.SetActive(true);

            meninaSelecionadoBtn.SetActive(false);
            meninaSelecionarBtn.SetActive(true);

            SetImageOpacity(meninoSelecionarImage, fullOpacity);
            SetImageOpacity(meninaSelecionarImage, fullOpacity);
        }
    }

    public void SelectGirl()
    {
        avatarSelecionado = "menina";
        PlayerPrefs.SetString("avatarSelecionado", avatarSelecionado);
        PlayerPrefs.Save();

        AplicarSelecaoMenina();
    }

    public void SelectBoy()
    {
        avatarSelecionado = "menino";
        PlayerPrefs.SetString("avatarSelecionado", avatarSelecionado);
        PlayerPrefs.Save();

        AplicarSelecaoMenino();
    }

    private void AplicarSelecaoMenina()
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

    private void AplicarSelecaoMenino()
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
