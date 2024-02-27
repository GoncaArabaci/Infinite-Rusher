using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        
    }
    public void GameOver() 
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
