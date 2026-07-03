using UnityEngine;

public class P2BulletChanger : MonoBehaviour
{
    public GameObject player2Bullet;
    public GameObject shootingPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Instantiate(player2Bullet, collision.gameObject.transform.position, transform.rotation);
                Destroy(collision.gameObject);
                Debug.Log("Player 2 Bullet is changed!");
            }
            }
        }
}
