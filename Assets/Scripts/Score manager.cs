using UnityEngine;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    public TextMeshProUGUI player1ScoreCount;
    public TextMeshProUGUI player2ScoreCount;

    public float player1Score;
    public float player2Score;

    public static float player1RoundScore;
    public static float player2RoundScore;

    public GameObject player1win;
    public GameObject player2win;

    public static bool player1HasWon;
    public static bool player2HasWon;

    private void Start()
    {
        player1Score = 0;
        player2Score = 0;

        player1RoundScore = 0;
        player2RoundScore = 0;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        player1ScoreCount.text = "Score: " + player1Score.ToString();
        player2ScoreCount.text = "Score: " + player2Score.ToString();

        if (player1HasWon == true)
        {
            player1win.gameObject.SetActive(true);
            // set the restart control here
        }

        if (player2HasWon == true)
        {
            player2win.gameObject.SetActive(true);
            // set the restart control here
        }
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
