using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement Stuff")]
    public float playerSpeed = 3f;
    public Vector2 movementInput;

    [Header("Shooting Stuff")]
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private float shootDelay = 0.5f;
    private bool allowShooting;

    [Header("Game Stuff")]
    public static bool isPaused;
    public static bool canPause;
    private float pauseCooldown = 3f;
    public GameObject pauseMenu;

    [SerializeField] private InputActionReference Shoot;

    public Renderer ren;
    [SerializeField] private GameObject Sprite;

    

    private void Start()
    {
        allowShooting = true;
        ren = Sprite.gameObject.GetComponent<Renderer>();

        if (PlayerInputHandler.player1Joined == true)
        {
            ren.material.color = Color.red;
        }

        if (PlayerInputHandler.player2Joined == true)
        {
            ren.material.color = Color.green;
        }

        isPaused = false;
        canPause = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * playerSpeed * Time.deltaTime);

        print(allowShooting);

        if (isPaused == false)
        {
            pauseMenu.gameObject.SetActive(false);
        }

        if (isPaused == true)
        {
            Pause();
            pauseMenu.gameObject.SetActive(true);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void ShootGun()
    {
        if (allowShooting == true)
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            StartCoroutine(ShootDelay());
            Debug.Log("bullet Fired!!!");
        }

        else
        {
            Debug.Log("Can't Shoot!");
        }
    }

    public void Restart()
    {
        if (Scoremanager.player1HasWon == true)
        {
            Time.timeScale = 1f;
            Scoremanager.player1RoundScore++;
            Scoremanager.player1HasWon = false;
            Scoremanager.player2HasWon = false;

            PlayerInputHandler.gameHasStarted = false;
            PlayerInputHandler.player1Joined = false;
            PlayerInputHandler.player2Joined = false;
            PlayerInputHandler.player3Joined = false;


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Scoremanager.player2HasWon == true)
        {
            Time.timeScale = 1f;
            Scoremanager.player2RoundScore++;
            Scoremanager.player1HasWon = false;
            Scoremanager.player2HasWon = false;

            PlayerInputHandler.gameHasStarted = false;
            PlayerInputHandler.player1Joined = false;
            PlayerInputHandler.player2Joined = false;
            PlayerInputHandler.player3Joined = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void DebugReset()
    {
        Time.timeScale = 1f;
        Scoremanager.player1HasWon = false;
        Scoremanager.player2HasWon = false;

        PlayerInputHandler.gameHasStarted = false;
        PlayerInputHandler.player1Joined = false;
        PlayerInputHandler.player2Joined = false;
        PlayerInputHandler.player3Joined = false;

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        if (isPaused == true)
        {
            isPaused = false;
            Time.timeScale = 1f;
            print(isPaused);
            StartCoroutine(PauseWait());
        }

        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            StartCoroutine(pauseDelay());
            print(isPaused);
        }

    }

    IEnumerator ShootDelay()
    {
        allowShooting = false;
        yield return new WaitForSeconds(shootDelay);
        allowShooting = true;
        Debug.Log("Player Can Shoot");
    }

    IEnumerator PauseWait()
    {
        canPause = false;
        yield return new WaitForSeconds(pauseCooldown);
        canPause = true;

    }

    IEnumerator pauseDelay()
    {
        canPause = false;
        yield return new WaitForSeconds(1f);
        canPause = true;
        print(canPause);
    }


}