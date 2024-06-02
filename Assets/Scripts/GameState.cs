using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public int zoomOut {get; set; } = 99;
    public int speedUp {get; set; } = 99;
    public int coins {get; set; } = 99;

    public int highestScore { get; set; } = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        LoadData();
    }

    public void SaveData()
    {
        SaveLoadSystem.SaveGameData();
    }

    public void LoadData()
    {
        GameData data = SaveLoadSystem.LoadGameData();

        zoomOut = data.zoomOutOwned;
        speedUp = data.speedUpOwned;
        coins = data.coinsOwned;
        highestScore = data.highestScore;
    }
}
