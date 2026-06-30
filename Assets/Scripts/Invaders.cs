using Unity.VisualScripting;
using System.Collections;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public float invaderMoveWaitTime;
    public float invaderSpeed;
    public float invaderShootCooldown;

    public bool touchedeftBarrier;
    public bool touchedRightBarrier;

    private void Start()
    {
        // starts the game off with the invaders moving left to right
        touchedRightBarrier = false;
        touchedeftBarrier = true;
    }

    private void Update()
    {
        if (!touchedeftBarrier && touchedRightBarrier) // is moving from right to left
        {
            transform.Translate(Vector2.left * invaderSpeed *  Time.deltaTime);
        }

        if (touchedeftBarrier && !touchedRightBarrier) // is moving from left to right
        {
            transform.Translate(Vector2.right * invaderSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("left barrier"))
        {
            touchedeftBarrier = true;
            MoveDown();
            touchedRightBarrier = false;
        }

        if (collision.gameObject.CompareTag("right barrier"))
        {
            touchedRightBarrier = true;
            MoveDown();
            touchedeftBarrier = false;
        }
    }

    public void MoveDown()
    {
        transform.Translate(0, -1.5f, 0);
    }


}
