using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    int score;
    public TextMeshProUGUI scoreText;
    int increaseRate = 1;
    int highScore;
    public TextMeshProUGUI highScoreText;
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        //highScore = PlayerPrefs.GetInt("highscore");
        //highScoreText.text = highScore.ToString();
    }
    void FixedUpdate()
    {
        UpdateScore();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
    }
    public void AddCoin()
    {
        score += 50;
        scoreText.text = score.ToString();
    }
    public void UpdateScore()
    {
        score += increaseRate;
        scoreText.text = score.ToString();

        //if(score > highScore)
        //{
        //    highScore = score;
        //    highScoreText.text = highScore.ToString();
        //    PlayerPrefs.SetInt("highscore", highScore);

        //}
    }
}
