using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

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
            Time.timeScale = 0f;
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

    public void Pause()
    {
        if (canPause == true)
        {
            if (isPaused == true)
            {
                isPaused = false;
                Time.timeScale = 1f;
                print(isPaused);
                StartCoroutine(PauseWait());
            }

            if (isPaused == false)
            {
                isPaused = true;
                StartCoroutine(pauseDelay());
                print(isPaused);
            }
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