using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI skillZoomOutText;
    public TextMeshProUGUI skillSpeedUpText;
    private void Awake()
    {
        coinsText.text = GameState.instance.coins.ToString();
        skillZoomOutText.text = GameState.instance.zoomOut.ToString();
        skillSpeedUpText.text = GameState.instance.speedUp.ToString();
    }
    public void StartGame(string mainScene)
    {
        SceneManager.LoadScene(mainScene);
    }

    public void OpenSetting(string settingScene)
    {
        SceneManager.LoadScene(settingScene);
    }
}
