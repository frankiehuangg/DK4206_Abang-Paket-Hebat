using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject coins;
    private TextMeshProUGUI coinsAmount;
    // Start is called before the first frame update
    void Awake() {
        coinsAmount = coins.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        coinsAmount.text = GameState.instance.coins.ToString();
    }

    public void BuyZoomOut()
    {
        GameState.instance.coins -= 1;
        GameState.instance.zoomOut += 1;
        GameState.instance.SaveData();
    }

    public void BuySpeedUp()
    {
        GameState.instance.coins -= 1;
        GameState.instance.speedUp += 1;
        GameState.instance.SaveData();
    }
}
