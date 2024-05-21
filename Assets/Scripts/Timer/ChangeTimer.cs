using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTimer : MonoBehaviour
{
    public Timer timer;

    public Image[] minuteDigitImages;
    public Image[] secondDigitImages;
    public Image timerBackgroundImage;
    public Sprite[] numberSprites;
    public Sprite[] timerBackgroundSprites;

    public float currentTime = 0;
    public int minutes;
    public int seconds;
    // Start is called before the first frame update
    private void Awake()
    {
        currentTime = 0;
        minutes = 0;
        seconds = 0;

        SetTimerSprites();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timerStarted != false)
        {
            currentTime = timer.currentTime + 1;
        }
        else
        {
            currentTime = 0;
        }
        
        minutes = Mathf.FloorToInt(currentTime / 60);
        seconds = Mathf.FloorToInt(currentTime % 60);
        SetTimerSprites();
    }

    private void SetTimerSprites()
    {
        string minuteString = minutes.ToString("00");
        string secondString = seconds.ToString("00");

        for (int i = 0; i < 2; i++)
        {
            int minuteDigit = int.Parse(minuteString[i].ToString());
            minuteDigitImages[i].sprite = numberSprites[minuteDigit];

            int secondDigit = int.Parse(secondString[i].ToString());
            secondDigitImages[i].sprite = numberSprites[secondDigit];
        }

        if (currentTime < 10)
        {
            timerBackgroundImage.sprite = timerBackgroundSprites[2];
        } 
        else if (currentTime < 30)
        {
            timerBackgroundImage.sprite = timerBackgroundSprites[1];
        }
        else
        {
            timerBackgroundImage.sprite = timerBackgroundSprites[0];
        }
    }
}
