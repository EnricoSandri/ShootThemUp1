using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public  static int score = 0;

    private void Awake()
    {
        SetUpSingleton();

       
    }
    
    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberOfGameSessions > 1)
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
    }

    public void ResetGameSession()
    {
        
        Destroy(gameObject);
    }
}
