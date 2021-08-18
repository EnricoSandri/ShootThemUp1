using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
//    public  int score = 0;

//    private void Awake()
//    {
//        SetUpSingleton();


//    }


//    private void SetUpSingleton()
//    {
//        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
//        if(numberOfGameSessions > 1)
//        {
//            Destroy(gameObject);
//        }
//        else
//        {
//            DontDestroyOnLoad(gameObject);
//        }
//    }

//    public int GetScore()
//    {
//        return score;

//    }

//    public void AddToScoreValue(int scoreValue)
//    {
//        score += scoreValue;

//    }

//    public void ResetGameSession()
//    {

//        Destroy(gameObject);
//    }

    public int score = 0 ;
    public static int highscore;
    public static GameSession instance;

    private void Awake()
    {
        SetUpSingleton();

        instance = this;
        highscore = PlayerPrefs.GetInt("highScore", 0);
        print("hiscore" + highscore);
    }


    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
        DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;

    }

    public void AddToScoreValue(int scoreValue)
    {
        score += scoreValue;
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highScore", highscore);
        }

    }

    public void ResetGameSession()
    {   

        Destroy(gameObject);
    }
}
