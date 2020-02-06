using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManager;
    [SerializeField] TextMeshProUGUI scoreGame;

    [SerializeField] GameObject endMenu;
    [SerializeField] TextMeshProUGUI menuTxt;
    [SerializeField] TextMeshProUGUI menuScore;

    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        uIManager = this;
        UpdateScore(GameManager.score);
    }

    public void UpdateScore(int scr)
    {
        scoreGame.text = "Score : "+scr;
    }

    public void EndGameStatus(bool isWon)
    {
        Time.timeScale = 0.0f;
        endMenu.SetActive(true);
        
        if (isWon)
        {
            menuTxt.text = "You Won";
            menuTxt.color = Color.green;
        }
        else
        {
            menuTxt.text = "You Lost";
            menuTxt.color = Color.red;
        }

        menuScore.text = "<b>Your Score :</b>" + GameManager.score;
    }

    public void OnRestartButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void OnMenuButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void ShowPasueMenu(bool ispaused)
    {
        pauseMenu.SetActive(ispaused);

        if (ispaused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }

    public void OnResumeButton()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        GameManager.gameManager.isPaused = false;
    }
}
