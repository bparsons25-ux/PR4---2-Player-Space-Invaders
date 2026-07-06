using UnityEngine;

public class invader : MonoBehaviour
{
    public int invaderType;
    public Scoremanager scoremanager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (invaderType == 1)
        {
            if (collision.gameObject.CompareTag("player1Bullet"))
            {
                scoremanager.Player1invaderType1();
            }

            if (collision.gameObject.CompareTag("player2Bullet"))
            {
                scoremanager.Player2invaderType2();
            }
        }

        if (invaderType == 2)
        {
            if (collision.gameObject.CompareTag("player1Bullet"))
            {
                scoremanager.Player1invaderType2();
            }

            if (collision.gameObject.CompareTag("player2Bullet"))
            {
                scoremanager.Player2invaderType2();
            }
        }

        if (invaderType == 3)
        {
            if (collision.gameObject.CompareTag("player1Bullet"))
            {
                scoremanager.Player1invaderType3();
            }

            if (collision.gameObject.CompareTag("player2Bullet"))
            {
                scoremanager.Player2invaderType3();
            }
        }

        if (collision.gameObject.CompareTag("BunkerPart"))
        {
            Destroy(collision.gameObject);
        }
    }

}
