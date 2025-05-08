using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeAvatar : MonoBehaviour
{
    public Image girlWaving;
    public Image boyWaving;
    public Image selectBoyImage;
    public Image selectGirlImage;

    public GameObject selectBoyBtn;
    public GameObject selectedBoyBtn;
    public GameObject selectGirlBtn;
    public GameObject selectedGirlBtn;

    private float fadedOpacity = 0.8f;
    private float fullOpacity = 1f;

    private string selectedAvatar = "";

    public void Start()
    {
        // Pegamos o avatar salvo, se existir
        selectedAvatar = PlayerPrefs.GetString("selected_avatar", "");

        if (selectedAvatar == "boy")
        {
            ApplySelectBoy();
        }
        else if (selectedAvatar == "girl")
        {
            ApplySelectGirl();
        }
        else
        {
            // Nenhum avatar selecionado: mostrar estado neutro
            SetImageOpacity(boyWaving, fullOpacity);
            SetImageOpacity(girlWaving, fullOpacity);

            selectedBoyBtn.SetActive(false);
            selectBoyBtn.SetActive(true);

            selectedGirlBtn.SetActive(false);
            selectGirlBtn.SetActive(true);

            SetImageOpacity(selectBoyImage, fullOpacity);
            SetImageOpacity(selectGirlImage, fullOpacity);
        }
    }

    public void SelectGirl()
    {
        selectedAvatar = "girl";
        PlayerPrefs.SetString("selected_avatar", selectedAvatar);
        PlayerPrefs.Save();

        ApplySelectGirl();
    }

    public void SelectBoy()
    {
        selectedAvatar = "boy";
        PlayerPrefs.SetString("selected_avatar", selectedAvatar);
        PlayerPrefs.Save();

        ApplySelectBoy();
    }

    private void ApplySelectGirl()
    {
        SetImageOpacity(selectBoyImage, fadedOpacity);
        SetImageOpacity(selectGirlImage, fullOpacity);

        SetImageOpacity(boyWaving, fadedOpacity);
        SetImageOpacity(girlWaving, fullOpacity);

        selectedBoyBtn.SetActive(false);
        selectBoyBtn.SetActive(true);

        selectedGirlBtn.SetActive(true);
        selectGirlBtn.SetActive(false);
    }

    private void ApplySelectBoy()
    {
        SetImageOpacity(selectBoyImage, fullOpacity);
        SetImageOpacity(selectGirlImage, fadedOpacity);

        SetImageOpacity(boyWaving, fullOpacity);
        SetImageOpacity(girlWaving, fadedOpacity);

        selectedBoyBtn.SetActive(true);
        selectBoyBtn.SetActive(false);

        selectedGirlBtn.SetActive(false);
        selectGirlBtn.SetActive(true);
    }

    void SetImageOpacity(Image img, float alpha)
    {
        if (img != null)
        {
            Color color = img.color;
            color.a = alpha;
            img.color = color;
        }
    }
}
