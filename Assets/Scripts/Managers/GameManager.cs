using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerMovement player;
    public bool isPaused = false;
    public int score = 0;

    public Timer timer;
    public DeliveryManager deliveryManager;

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
       
    }

    public void StartGame()
    {
        deliveryManager.GameStart();
        timer.StartTimer();
    }

    public void GameOver()
    {
        deliveryManager.enabled = false;
    }
}
