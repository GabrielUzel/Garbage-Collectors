﻿using UnityEngine;
using UnityEngine.UI;

public class LifeQuantityManager : MonoBehaviour
{
  private int quantityLifes;
  private int initialQuantitiyLifes;
  private AudioSource audioSrc;
  public static LifeQuantityManager Instance;
  public Image lifes;
  public AudioClip sound;


  [Header("Sprites - 10 vidas")]
  public Sprite[] lifeSpritesTen;

  [Header("Sprites - 6 vidas")]
  public Sprite[] lifeSpritesSix;

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
    quantityLifes = LoadLevelsInfo.Instance.GetLifes();
    initialQuantitiyLifes = quantityLifes;
    DefineLifeQuantity(initialQuantitiyLifes);
  }

  public void LoseHeart()
  {
    SoundEffectsController.Instance.playSoundEffect("wrongWaste");
    quantityLifes = Mathf.Max(0, quantityLifes - 1);

    Sprite[] selectedArray = initialQuantitiyLifes == 10 ? lifeSpritesTen : lifeSpritesSix;
    int maxIndex = selectedArray.Length - 1;

    if (quantityLifes >= 0 && quantityLifes <= maxIndex)
    {
      lifes.sprite = selectedArray[quantityLifes];
    }
    else
    {
      lifes.sprite = selectedArray[0];
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

  public void DefineLifeQuantity(int quantityLifes)
  {
    if (quantityLifes == 10)
    {
      lifes.sprite = lifeSpritesTen[10];
    }
    else
    {
      lifes.sprite = lifeSpritesSix[6];
    }
  }

  public int GetErros()
  {
    return initialQuantitiyLifes - quantityLifes;
  }
}
