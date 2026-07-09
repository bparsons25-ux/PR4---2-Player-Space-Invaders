using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class RandomInvaderShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject[] enemyPositions;
    public int enemyNumber;
    public float randomWaitTime;
    public float shootTimer;

    public void Start()
    {
        randomWaitTime = Random.Range(3f, 5f);
        enemyNumber = Random.Range(1, 10);
    }

    public void Update()
    {
        if (PlayerInputHandler.gameHasStarted == true)
        {
            shootTimer = shootTimer + Time.deltaTime;

            if (shootTimer > randomWaitTime)
            {
                Instantiate(bulletPrefab, enemyPositions[enemyNumber].transform.position, transform.rotation);
                enemyNumber = Random.Range(1, 10);

                randomWaitTime = Random.Range(3f, 5f);
                shootTimer = 0f;

            }
        }
    }








}
