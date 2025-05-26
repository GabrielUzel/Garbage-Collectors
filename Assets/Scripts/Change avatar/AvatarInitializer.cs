using UnityEngine;

public class AvatarInitializer : MonoBehaviour
{
    public GameObject girlAvatar;
    public GameObject boyAvatar;

    public void Start()
    {
        string avatar = PlayerPrefs.GetString("selected_avatar", "girl");

        if (avatar == "boy")
        {
            boyAvatar.SetActive(true);
            girlAvatar.SetActive(false);
        }
        else
        {
            girlAvatar.SetActive(true);
            boyAvatar.SetActive(false);
        }
    }
}