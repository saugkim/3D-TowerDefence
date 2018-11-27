using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{

    public static bool isGameOver;

    public static int currentGold;
    public int startGold = 1000;

    public static int lives;
    public int startLives = 30;

    [SerializeField]
    GameObject GameOverPanel;

    void Start ()
    {
        currentGold = startGold;
        lives = startLives;
        isGameOver = false;
        GameOverPanel.SetActive(false);
    }

	void Update ()
    {
	    if(lives == 0 && !isGameOver)
        {
            GameOver();
        }
	}

    private void GameOver()
    {
        isGameOver = true;
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}