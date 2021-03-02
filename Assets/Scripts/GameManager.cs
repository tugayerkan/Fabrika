using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<BumperCar> Cars = new List<BumperCar>();
    [SerializeField] public BumperCar bumper;
    public UIMenu UI;
    public static GameManager singleton;
    public static GameState gameState = GameState.Playing;
    public bool isGameOver = false;

    private void Awake()
    {
        singleton = this;
    }
    public void CarCrashed()
    {
        for (int i = 0; i <= bumper.id; i++)
        {
            if (bumper.isCrashed == true && gameState == GameState.Playing)
            {
                GameOver(true);
            }
        }
    }
    public void GameOver(bool isWon)
    {
        gameState = GameState.Over;
        if (isWon)
        {
            UI.WinText();
            UI.lostText.SetActive(false);
            isGameOver = true;
        }
        for (int i = 0; i < Cars.Count; i++)
        {
            Cars[i].GameOver();
        }
    }

    public void ResetLevel()
    {
        for (int i = 0; i < Cars.Count; i++)
        {
            Cars[i].ResetCar();
        }
    }
}
