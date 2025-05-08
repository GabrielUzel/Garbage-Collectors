using UnityEngine;

public class Avatar : MonoBehaviour
{

    private string tag = "Waste";
    private int totalWaste = 30;
    public Sprite[] sprites;
    private string selectedAvatar = "";
    private bool boy;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake(){
        selectedAvatar = PlayerPrefs.GetString("selected_avatar", "");

        if (selectedAvatar == "boy"){
            boy = true;
        }
        else{
            boy = false;
        }
    }
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        if(boy == true){
                sr.sprite = sprites[0];
            }
            else{
                sr.sprite = sprites[3];
            }
    }   

    // Update is called once per frame
    void Update()
    {
        GameObject[] wastes = GameObject.FindGameObjectsWithTag(tag);
        UpdateSprite(wastes.Length);
    }
    
    void UpdateSprite(int wasteAmount){
        int wastePercentage = (100*wasteAmount)/totalWaste;
        if (wastePercentage <= 30){
            if(boy == true){
                sr.sprite = sprites[2];
            }
            else{
                sr.sprite = sprites[5];
            }
        }else if (wastePercentage <= 60){
            if(boy == true){
                sr.sprite = sprites[1];
            }
            else{
                sr.sprite = sprites[4];
            }
        }
    }
}
