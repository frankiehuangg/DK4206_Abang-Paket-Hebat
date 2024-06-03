using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public TextMeshProUGUI settingText;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI sfxText;
    public TextMeshProUGUI languageText;

    public GameObject englishCheck;
    public GameObject indonesiaCheck;

    public Slider musicSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        if (GameState.instance != null)
        {
            if (GameState.instance.language == "English")
            {
                SetEnglish();
            }
            else
            {
                SetIndonesia();
            }
            musicSlider.value = GameState.instance.musicLevel;
            sfxSlider.value = GameState.instance.sfxLevel;
        }
        else
        {
            SetEnglish();
            musicSlider.value = 1;
            sfxSlider.value = 1;
        }

    }
    public void BackToMenu(string menuScene)
    {
        SceneManager.LoadScene(menuScene);
    }

    public void ChangeToEnglish()
    {
        if (GameState.instance != null)
        {
            GameState.instance.language = "English";
        }
        SetEnglish();
    }

    public void ChangeToIndonesia()
    {
        if (GameState.instance != null)
        {
            GameState.instance.language = "Indonesia";
        }
        SetIndonesia();
    }

    private void SetEnglish()
    {
        settingText.text = "SETTINGS";
        musicText.text = "Music";
        sfxText.text = "Sfx";
        languageText.text = "Language";

        indonesiaCheck.SetActive(false);
        englishCheck.SetActive(true);
    }

    private void SetIndonesia()
    {
        settingText.text = "PENGATURAN";
        musicText.text = "Musik";
        sfxText.text = "Sfx";
        languageText.text = "Bahasa";

        englishCheck.SetActive(false);
        indonesiaCheck.SetActive(true);
    }
}
