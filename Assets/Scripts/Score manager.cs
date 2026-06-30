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



}
