using UnityEngine;

public class P1BulletChanger : MonoBehaviour
{
    public GameObject player1Bullet;
    public Transform bulletPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
           Instantiate(player1Bullet, bulletPos.transform.position, transform.rotation);
            Debug.Log("Player 1 Bullet is changed!");
        }
    }
}
