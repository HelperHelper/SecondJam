using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameIsOver;

    public GameObject gameOverUI;

    private void Start()
    {
        gameIsOver = false;
    }
    void Update()
    {
        if (gameIsOver == true)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("level won");
    }
}
