using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject blur;
    public Sprite[] enTutorial;
    public Sprite[] idTutorial;

    public Image leftPage;
    public Image rightPage;

    private int currentPage = 0;

    private void Awake()
    {
        if (GameState.instance != null)
        {
            if (GameState.instance.language == "English")
            {
                leftPage.sprite = enTutorial[0];
                rightPage.sprite = enTutorial[1];
            }
            else
            {
                leftPage.sprite = idTutorial[0];
                rightPage.sprite = idTutorial[1];
            }
        }
        blur.SetActive(true);
    }

    public void TurnPage(bool isNext)
    {
        if ((currentPage == 0 && !isNext) || (currentPage == 3 && isNext))
        {
            this.gameObject.SetActive(false);
            blur.SetActive(false);
            GameManager.instance.StartGame();
        }
        else
        {
            if (!isNext)
            {
                currentPage -= 1;
            }
            else
            {
                currentPage += 1;
            }
            
            if (GameState.instance != null)
            {
                if (GameState.instance.language == "English")
                {
                    leftPage.sprite = enTutorial[0 + currentPage * 2];
                    rightPage.sprite = enTutorial[1 + currentPage * 2];
                }
                else
                {
                    leftPage.sprite = idTutorial[0 + currentPage * 2];
                    rightPage.sprite = idTutorial[1 + currentPage * 2];
                }
            }
            
        }
    }
}
