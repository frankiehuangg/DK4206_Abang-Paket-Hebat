using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip mainMenuBgm;

    public TextMeshProUGUI playText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI skillZoomOutText;
    public TextMeshProUGUI skillSpeedUpText;
    private void Awake()
    {
        if (GameState.instance.language == "English")
        {
            playText.text = "Play";
        }
        else
        {
            playText.text = "Main";
        }

        coinsText.text = GameState.instance.coins.ToString();
        skillZoomOutText.text = GameState.instance.zoomOut.ToString();
        skillSpeedUpText.text = GameState.instance.speedUp.ToString();
        GameState.instance.SetMusic(mainMenuBgm);
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
