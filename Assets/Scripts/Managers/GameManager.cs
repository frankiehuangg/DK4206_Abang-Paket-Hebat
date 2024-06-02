using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerMovement player;
    public bool isPaused = false;
    public bool isPlaying = false;
    public int score = 0;
    public int coins = 0;
    public int delivered = 0;
    public int picked = 0;

    public Timer timer;
    public DeliveryManager deliveryManager;
    public GameObject canvasOnPlay;
    public GameObject canvasGameOver;

    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        StartGame();
       
    }

    private void Update()
    {
        if (isPlaying)
        {
            //SetTextOnPlay();
        }
    }

    public void StartGame()
    {
        Reset();
        deliveryManager.GameStart();
        timer.StartTimer();
        isPlaying = true;
        player.enabled = true;
    }

    public void GameOver()
    {
        if (score > GameState.instance.highestScore)
        {
            GameState.instance.highestScore = score;
        }
        deliveryManager.GameOver();
        timer.ResetTimer();
        isPlaying = false;
        canvasGameOver.SetActive(true);
        player.enabled = false;
        GameState.instance.coins += coins;
        GameState.instance.SaveData();
    }

    private void Reset()
    {
        score = 0;
        coins = 0;
        delivered = 0;
        picked = 0;
    }

    private void SetTextOnPlay()
    {
        TextMeshProUGUI pointsText = canvasOnPlay.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI deliveredText = canvasOnPlay.transform.GetChild(4).GetComponent<TextMeshProUGUI>();

        pointsText.text = "Points: " + score;
        deliveredText.text = "Delivered: " + delivered; 
    }

    private void SetTextOnOver()
    {
        TextMeshProUGUI pointsText = canvasGameOver.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI deliveredText = canvasGameOver.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        pointsText.text = "Points: " + score;
        deliveredText.text = "Delivered: " + delivered;
    }

    public void CloseGameOverCanvas()
    {
        canvasGameOver.SetActive(false);
    }
}
