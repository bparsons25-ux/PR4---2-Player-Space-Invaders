using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;

    public static bool player1Joined = false;
    public static bool player2Joined = false;
    public static bool player3Joined = false;

    public GameObject pressCtrlToStart;
    public GameObject pressSpaceToStart;

    public static bool gameHasStarted;

    public static int playerCount;

    public GameObject player1BulletTransformer;
    public GameObject player2BulletTransformer;

    private void Start()
    {
        pressCtrlToStart.gameObject.SetActive(true);
        pressSpaceToStart.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Keyboard.current == null) return;

        if (!player1Joined && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var player = PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard", pairWithDevice: Keyboard.current);

            if (spawnPoints.Length > 0)
            {
                player.transform.position = spawnPoints[0].position; // sets the player position to equals a spawn point
                player1BulletTransformer.transform.parent = player.transform;
            }

            player1Joined = true;
            pressSpaceToStart.gameObject.SetActive(false);
        }

        if (!player2Joined && Keyboard.current.rightCtrlKey.wasPressedThisFrame)
        {
            var player = PlayerInput.Instantiate(playerPrefab, controlScheme: "Arrows", pairWithDevice: Keyboard.current);

            if (spawnPoints.Length > 1)
            {
                player.transform.position = spawnPoints[1].position; // sets the player position to equals a spawn point
                player.transform.rotation = spawnPoints[1].rotation; // sets the player rotation to the same as the spawn points rotation
                player2BulletTransformer.transform.parent = player.transform;
            }

            player2Joined = true;
            pressCtrlToStart.gameObject.SetActive(false);
        }

        foreach (var gamePad in Gamepad.all)
        {
            if (!player3Joined && gamePad.buttonSouth.wasPressedThisFrame)
            {
                var player = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: gamePad);

                player3Joined = true;
                player1Joined = true;
                pressSpaceToStart.gameObject.SetActive(false);

                player1BulletTransformer.transform.parent = player.transform;

            }
        }

        if (player1Joined == true || player2Joined == true)
        {
            if (player1Joined == true || player2Joined == true)
            {
                gameHasStarted = true;
            }
        }
    }
}
