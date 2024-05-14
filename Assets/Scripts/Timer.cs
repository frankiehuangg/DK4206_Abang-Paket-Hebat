using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool timerStarted = false;

    public TextMeshProUGUI timerText;
    public float currentTime;
    public bool countDown;

    public bool hasLimit;
    public float timerLimit;

    private void Awake()
    {
        SetTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
            {
                TimerOver();
            }
            SetTimerText();
        }
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.00");
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public void TimerOver()
    {
        currentTime = timerLimit;
        SetTimerText();
        timerStarted = false;
        timerText.color = Color.red;

        GameManager.instance.GameOver();
    }
}
