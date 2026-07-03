using UnityEngine;

public class P2BulletChanger : MonoBehaviour
{
    public GameObject player2Bullet;
    public Transform bulletPos2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
           Instantiate(player2Bullet, bulletPos2.transform.position, transform.rotation);
            Debug.Log("Player 2 Bullet is changed!");
        }
    }
}
