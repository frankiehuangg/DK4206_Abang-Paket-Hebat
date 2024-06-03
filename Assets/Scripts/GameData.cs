using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int coinsOwned;
    public int zoomOutOwned;
    public int speedUpOwned;
    public int highestScore;
    public string language;
    public float musicLevel;
    public float sfxLevel;

    public GameData()
    {
        GameState gameState = GameState.instance;
        coinsOwned = gameState.coins;
        zoomOutOwned = gameState.zoomOut;
        speedUpOwned = gameState.speedUp;
        highestScore = gameState.highestScore;
        language = gameState.language;
        musicLevel = gameState.musicLevel;
        sfxLevel = gameState.sfxLevel;
    }
}
