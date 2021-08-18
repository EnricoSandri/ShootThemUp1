using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour {

    Text hiScoreText;
    GameSession gameSession;
	
    // Use this for initialization
	void Start ()
    {
        hiScoreText = GetComponent<Text>();
        gameSession = GetComponent<GameSession>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        hiScoreText.text = ("" + PlayerPrefs.GetInt("highScore", 0));
	}
}
