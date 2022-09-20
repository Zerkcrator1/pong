using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player")]
    public GameObject playerPaddle;
    public GameObject playerGoal;

    [Header("Enemy")]
    public GameObject enemyPaddle;
    public GameObject enemyGoal;


    [Header("Score UI")]
    public GameObject playerText;
    public GameObject enemyText;

    private int playerScore;
    private int enemyScore;


    public void PlayerScored()
    {
        playerScore++;
        playerText.GetComponent<TextMeshProUGUI>().text = playerScore.ToString();
    }
    
    public void EnemyScored()
    {
        enemyScore++;
        enemyText.GetComponent<TextMeshProUGUI>().text = enemyScore.ToString();
    }

    public void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        playerPaddle.GetComponent<Paddle>().Reset();
        enemyPaddle.GetComponent<Paddle>().Reset();
    }
}
