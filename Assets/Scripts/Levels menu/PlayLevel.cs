using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayLevel : MonoBehaviour
{
    public GameObject PopUpPanel;
    public GameObject LevelButtonsGroup;
    public Button ReturnToHomeButton;
    public Image Background;

    private Color normalColor = new Color(255, 255, 255, 1);
    private Color fadedColor = new Color(255, 255, 255, 0.5f);
    private List<Button> ActiveButtons = new List<Button>();

    void Start()
    {
        PopUpPanel.SetActive(false);
    }

    public void LoadPopUp(Button clickedButton)
    {
        PopUpPanel.SetActive(true);
        ReturnToHomeButton.interactable = false;

        foreach (Transform child in LevelButtonsGroup.transform)
        {
            Button btn = child.GetComponent<Button>();

            if (btn != null && btn.interactable && btn != clickedButton) {
                btn.interactable = false;
                ActiveButtons.Add(btn);
            }
        }

        Background.color = fadedColor;
    }

    public void ClosePopUp()
    {
        PopUpPanel.SetActive(false);
        ReturnToHomeButton.interactable = true;

        foreach (Button btn in ActiveButtons)
        {
            if (btn != null) {
                btn.interactable = true;
            }
        }

        ActiveButtons.Clear();

        Background.color = normalColor;
    }
}