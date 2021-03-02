using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public static bool gameisFinished = false;
    public GameObject MenuUI;
    public Movement move;
    public GameObject winText;
    public GameObject lostText;

    void Update()
    {
        if (GameManager.gameState == GameState.Over)
        {
            GameManager.gameState = GameState.Standby;
            Restart();
        }
    }
    public void Restart()
    {
        gameisFinished = true;
        MenuUI.SetActive(true);
    }

    public void StartButton()
    {
        move.ResetPlayer();
        MenuUI.SetActive(false);
        winText.SetActive(false);
        lostText.SetActive(false);
        GameManager.singleton.ResetLevel();
        GameManager.gameState = GameState.Playing;
    }
    public void WinText()
    {
        winText.SetActive(true);
    }
    public void LostText()
    {
        lostText.SetActive(true);
    }

}
