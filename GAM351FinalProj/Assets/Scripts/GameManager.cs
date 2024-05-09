using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    bool gameOver = false;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }
    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadLevel();
            }
        }
    }
    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
        gameOver = true;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
