using UnityEngine;

public class P1BulletChanger : MonoBehaviour
{
    public GameObject player1Bullet;
    public GameObject shootingPoint;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(player1Bullet, collision.gameObject.transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Debug.Log("Player 1 Bullet is changed!");
        }
    }
}
