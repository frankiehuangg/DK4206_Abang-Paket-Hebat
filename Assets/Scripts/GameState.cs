using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public int zoomOut {get; set; } = 0;
    public int speedUp {get; set; } = 0;
    public int coins {get; set; } = 50;
    public int highestScore { get; set; } = 0;
    public string language { get; set; } = "English";
    public float musicLevel { get; set; } = 100;
    public float sfxLevel { get; set; } = 100;

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
        language = data.language;
        musicLevel = data.musicLevel;
        sfxLevel = data.sfxLevel;
    }
}
