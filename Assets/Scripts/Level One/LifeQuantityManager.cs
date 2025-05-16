using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Level_One
{
   public class LifeQuantityManager : MonoBehaviour

    {
        public static LifeQuantityManager Instance;
        public Image lifes;
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
        int quantityLifes = 10;

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

        public void LoseHeart()
        {
            quantityLifes--;

            if (quantityLifes < 0)
                quantityLifes = 0;

            switch (quantityLifes)
            {
                case 0:
                    lifes.sprite = lifeEmpty; break;
                case 1:
                    lifes.sprite = oneLifeHalf; break;
                case 2:
                    lifes.sprite = oneLifeFull; break;
                case 3:
                    lifes.sprite = twoLivesHalf; break;
                case 4:
                    lifes.sprite = twoLivesFull; break;
                case 5:
                    lifes.sprite = threeLivesHalf; break;
                case 6:
                    lifes.sprite = threeLivesFull; break;
                case 7:
                    lifes.sprite = fourLivesHalf; break;
                case 8:
                    lifes.sprite= fourLivesFull; break;
                case 9:
                    lifes.sprite = fiveLivesHalf; break;
                case 10:
                    lifes.sprite = fiveLivesFull; break;
                default:
                    lifes.sprite = lifeEmpty; break;
            }
            if(quantityLifes == 0)
            {
                loseGame();
            }

        }

        public void loseGame()
        {
          //  SceneManager.LoadScene("Lost_Scene");
        }
    }
}
