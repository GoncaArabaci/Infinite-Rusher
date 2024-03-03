using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject gameOverPanel;
    void Start()
    {

    }

    void Update()
    {
        
    }
    public void GameOver() 
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        gameOver = false;
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
