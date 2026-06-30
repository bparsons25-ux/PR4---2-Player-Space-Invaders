using Unity.VisualScripting;
using System.Collections;
using UnityEngine;

public class Invaders : MonoBehaviour
{

    public float invaderSpeed;
    public float invaderShootCooldown;

    public bool touchedeftBarrier;
    public bool touchedRightBarrier;

    private bool isGoingDown;
    

    private void Start()
    {
        // starts the game off with the invaders moving left to right
        touchedRightBarrier = false;
        touchedeftBarrier = true;

        isGoingDown = true;
    }

    private void Update()
    {
        if (PlayerInputHandler.gameHasStarted == true) // checks if the game has started boolean appears
        {
            if (touchedeftBarrier == false) // is moving from right to left
            {
                if (touchedRightBarrier == true)
                {
                    transform.Translate(Vector2.left * invaderSpeed * Time.deltaTime);
                }
            }

            if (touchedeftBarrier == true) // is moving from left to right
            {
                if (touchedRightBarrier == false)
                {
                    transform.Translate(Vector2.right * invaderSpeed * Time.deltaTime);
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("left barrier"))
        {
            touchedeftBarrier = true;
            Debug.Log("Touched Left Barrier!");
            touchedRightBarrier = false;

            if (isGoingDown == true)
            {
                MoveDown();
            }

            else
            {
                MoveUp();
            }
        }

        if (collision.gameObject.CompareTag("right barrier"))
        {
            touchedRightBarrier = true;
            Debug.Log("Touched Right Barrier!");
            touchedeftBarrier = false;

            if (isGoingDown == true)
            {
                MoveDown();
            }

            else
            {
                MoveUp();
            }
        }
    }


    public void MoveDown()
    {
        transform.Translate(0, -0.5f, 0);
    }
    public void MoveUp()
    {
        transform.Translate(0, 0.5f, 0);
    }



}
