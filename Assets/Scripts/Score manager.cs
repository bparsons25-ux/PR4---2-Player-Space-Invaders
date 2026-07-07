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

    public TextMeshProUGUI roundCounterText;

    public static bool player1HasWon;
    public static bool player2HasWon;

    private void Start()
    {
        player1RoundScore = PlayerPrefs.GetFloat("player1RoundScore", 0);
        player2RoundScore = PlayerPrefs.GetFloat("player2RoundScore", 0);

        player1Score = PlayerPrefs.GetFloat("player1Score", 0);
        player2Score = PlayerPrefs.GetFloat("player2Score", 0);
    }

    private void Update()
    {
        player1ScoreCount.text = "Score: " + player1Score.ToString();
        player2ScoreCount.text = "Score: " + player2Score.ToString();

        roundCounterText.text = player1RoundScore.ToString() + " - " + player2RoundScore.ToString();

        PlayerPrefs.SetFloat("player1Score", player1Score);
        PlayerPrefs.SetFloat("player2Score", player2Score);

        PlayerPrefs.SetFloat("player1RoundScore", player1RoundScore);
        PlayerPrefs.SetFloat("player2RoundScore", player2RoundScore);

        if (player1HasWon == true)
        {
            player1win.gameObject.SetActive(true);
            // set the restart control here
        }

        else
        {
            player1win.gameObject.SetActive(false);
        }

        if (player2HasWon == true)
        {
            player2win.gameObject.SetActive(true);
            // set the restart control here
        }

        else
        {
            player2win.gameObject.SetActive(false);
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
