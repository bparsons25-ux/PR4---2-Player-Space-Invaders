using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float shootingSpeed = 3;
    private Rigidbody2D rb;

    public int bulletType;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * shootingSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("BunkerPart"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (bulletType == 1)
        {
            if (collision.gameObject.CompareTag("player"))
            {
                Destroy(collision.gameObject);
                Scoremanager.player1HasWon = true;
                Time.timeScale = 0f;
            }

            if (collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Debug.Log("Enemy Destroyed!");
                // Play Shoot SFX
            }
        }   

        if (bulletType == 2)
        {
            if (collision.gameObject.CompareTag("player"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Scoremanager.player2HasWon = true;
                Time.timeScale = 0f;
            }

            if (collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Debug.Log("Enemy Destroyed!");
                // Play Shoot SFX
            }
        }

        if (bulletType == 3)
        {
            if (collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Debug.Log("Enemy Destroyed!");
                // Play Shoot SFX
            }

        }
    }


 

}
