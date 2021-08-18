using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadLevel : MonoBehaviour
{
    public float delayInSeconds = 3f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGameSession();
    }


    public void ScoreMenu()
    {
        StartCoroutine(WaitAndLoadScoreMenu());
    }


    public IEnumerator WaitAndLoadScoreMenu()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("ScoreMenu");
    }

    public void GameOver()
    {
        StartCoroutine(WaitAndLoad());

    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }
    public void LoadLevel2()
    {
        StartCoroutine(WaitAndLoadLevel2());
    }
    public IEnumerator WaitAndLoadLevel2()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Level2");
    }
    public void EndGame()
    {
        Application.Quit();
    }

     
}
