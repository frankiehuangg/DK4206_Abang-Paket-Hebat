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

    public GameData()
    {
        GameState gameState = GameState.instance;
        coinsOwned = gameState.coins;
        zoomOutOwned = gameState.zoomOut;
        speedUpOwned = gameState.speedUp;
        highestScore = gameState.highestScore;

    }
}
