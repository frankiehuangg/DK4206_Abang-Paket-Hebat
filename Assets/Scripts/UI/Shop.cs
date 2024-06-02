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
    void Start()
    {
        Debug.Log(GameState.instance.coins);
        coinsAmount.text = GameState.instance.coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
