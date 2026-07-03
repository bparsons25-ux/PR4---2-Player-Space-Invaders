using UnityEngine;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    public TextMeshProUGUI player1ScoreCount;
    public TextMeshProUGUI player2ScoreCount;

    public float player1Score;
    public float player2Score;

    private void Start()
    {
        player1Score = 0;
        player2Score = 0;
    }

    private void Update()
    {
        player1ScoreCount.text = "Score: " + player1Score.ToString();
        player2ScoreCount.text = "Score: " + player2Score.ToString();
    }

    public void Player1invaderType1()
    {
        player1Score += 10f;
    }

    public void Player1invaderType2()
    {
        player1Score += 20f;
    }

    public void Player1invaderType3()
    {
        player1Score += 30f;
    }

    public void Player2invaderType1()
    {
        player2Score += 10f;
    }

    public void Player2invaderType2()
    {
        player2Score += 20f;
    }

    public void Player2invaderType3()
    {
        player2Score += 30f;
    }




}
