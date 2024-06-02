using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI pickUpText;
    public TextMeshProUGUI deliverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI coinsText;
    private void OnEnable()
    {
        pickUpText.text = GameManager.instance.picked.ToString();
        deliverText.text = GameManager.instance.delivered.ToString();
        scoreText.text = GameManager.instance.score.ToString();
        coinsText.text = GameManager.instance.coins.ToString();
        highscoreText.text = GameState.instance.highestScore.ToString();

    }
    public void Retry(string mainScene)
    {
        SceneManager.LoadScene(mainScene);
    }

    public void BackToMenu(string menuScene)
    {
        SceneManager.LoadScene(menuScene);
    }
}
