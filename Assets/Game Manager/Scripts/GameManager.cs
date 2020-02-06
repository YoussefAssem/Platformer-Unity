using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public static int score;
    public bool isPaused;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            isPaused = !isPaused;

            Paused(isPaused);
        }
    }

    private void Paused(bool isPaused)
    {
        UIManager.uIManager.ShowPasueMenu(isPaused);
    }

    private void Start()
    {
        gameManager = this;
        DontDestroyOnLoad(gameManager);
    }
    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
        UIManager.uIManager.UpdateScore(score);
    }

    public void LevelEnd()
    {
        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
            WinGame();
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void WinGame()
    {
        UIManager.uIManager.EndGameStatus(true);
        score = 0;
    }

    public void GameOver()
    {
        UIManager.uIManager.EndGameStatus(false);
        score = 0;
    }
}
