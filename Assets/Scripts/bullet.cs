using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float shootingSpeed = 3;
    private Rigidbody2D rb;

    public GameObject player1Bullet;
    public GameObject player2Bullet;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * shootingSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Enemy Destroyed!");
            // Add Points Here????
            // Play Shoot SFX
        }

        if (collision.CompareTag("BunkerPart"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }


 

}
