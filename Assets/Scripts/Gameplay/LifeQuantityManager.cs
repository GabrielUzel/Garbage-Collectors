using UnityEngine;
using UnityEngine.UI;

public class LifeQuantityManager : MonoBehaviour
{
    private int quantityLifes;
    private AudioSource audioSrc;
    public static LifeQuantityManager Instance;
    public Image lifes;
    public AudioClip sound;           
    public Sprite fiveLivesFull;
    public Sprite fiveLivesHalf;
    public Sprite fourLivesFull;
    public Sprite fourLivesHalf;
    public Sprite threeLivesFull;
    public Sprite threeLivesHalf;
    public Sprite twoLivesFull;
    public Sprite twoLivesHalf;
    public Sprite oneLifeFull;
    public Sprite oneLifeHalf;
    public Sprite lifeEmpty;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (audioSrc == null)
            audioSrc = gameObject.AddComponent<AudioSource>();
        quantityLifes = LoadLevelsInfo.Instance.GetLifes();
    }

    public void LoseHeart()
    {
        quantityLifes--;
        audioSrc.PlayOneShot(sound);
        switch (quantityLifes)
        {
            case 0:
                lifes.sprite = lifeEmpty;
                break;
            case 1:
                lifes.sprite = oneLifeHalf;
                break;
            case 2:
                lifes.sprite = oneLifeFull;
                break;
            case 3:
                lifes.sprite = twoLivesHalf;
                break;
            case 4:
                lifes.sprite = twoLivesFull;
                break;
            case 5:
                lifes.sprite = threeLivesHalf;
                break;
            case 6:
                lifes.sprite = threeLivesFull;
                break;
            case 7:
                lifes.sprite = fourLivesHalf;
                break;
            case 8:
                lifes.sprite = fourLivesFull;
                break;
            case 9:
                lifes.sprite = fiveLivesHalf;
                break;
            case 10:
                lifes.sprite = fiveLivesFull;
                break;
            default:
                lifes.sprite = lifeEmpty;
                break;
        }

        if (quantityLifes == 0)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        FindFirstObjectByType<LevelResult>().ShowPopUp("Life");
    }
}
