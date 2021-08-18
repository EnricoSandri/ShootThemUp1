using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public bool muted;
    [SerializeField] TextMeshProUGUI mutetext;
    [SerializeField] AudioSource sound;

    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (muted)
        {
            sound.enabled = false;
            mutetext.text = "Unmute";

        }
        else if (!muted)
        {
            mutetext.text = "Mute";
            sound.enabled = true;

        }


    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
    public void Mute()
    {
        muted = !muted;
    }
    public void LoadNextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
