using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry(string mainScene)
    {
        SceneManager.LoadScene(mainScene);
    }

    public void BackToMenu(string menuScene)
    {
        SceneManager.LoadScene(menuScene);
    }
}
