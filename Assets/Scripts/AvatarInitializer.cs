using UnityEngine;

public class AvatarInitializer : MonoBehaviour
{
    public GameObject meninaAvatar;
    public GameObject meninoAvatar;

    void Start()
    {
        string avatar = PlayerPrefs.GetString("avatarSelecionado", "menina");

        if (avatar == "menino")
        {
            meninoAvatar.SetActive(true);
            meninaAvatar.SetActive(false);
        }
        else
        {
            meninaAvatar.SetActive(true);
            meninoAvatar.SetActive(false);
        }
    }
}