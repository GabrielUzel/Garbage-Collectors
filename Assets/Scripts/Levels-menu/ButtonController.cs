using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public int Level = 2;
    public Button LevelOne;
    public Button LevelTwo;
    public Button LevelThree;
    public Button LevelFour;
    public Button LevelFive;

    void Start()
    {
        LevelTwo.interactable = false;
        LevelThree.interactable = false; 
        LevelFour.interactable = false; 
        LevelFive.interactable = false;  

        if(Level == 2){
            LevelTwo.interactable = true;
            LevelThree.interactable = false; 
            LevelFour.interactable = false; 
            LevelFive.interactable = false;  
            Image ImageButton = LevelTwo.GetComponent<Image>();
            ImageButton.color = new Color(1f, 1f, 1f, 0f);
        }

        if(Level == 3){
            LevelTwo.interactable = true;
            LevelThree.interactable = true; 
            LevelFour.interactable = false; 
            LevelFive.interactable = false;  
            Image ImageButton = LevelThree.GetComponent<Image>();
            ImageButton.color = new Color(1f, 1f, 1f, 0f);
        }

        if(Level == 4){
            LevelTwo.interactable = true;
            LevelThree.interactable = true; 
            LevelFour.interactable = true; 
            LevelFive.interactable = false;              
            Image ImageButton = LevelFour.GetComponent<Image>();
            ImageButton.color = new Color(1f, 1f, 1f, 0f);
        }

        if(Level == 5){
            LevelTwo.interactable = true;
            LevelThree.interactable = true; 
            LevelFour.interactable = true; 
            LevelFive.interactable = true;              
            Image ImageButton = LevelFive.GetComponent<Image>();
            ImageButton.color = new Color(1f, 1f, 1f, 0f);
        }

    }
}
