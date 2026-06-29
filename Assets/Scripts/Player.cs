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

    [SerializeField] private InputActionReference Shoot;

    private void Start()
    {
        allowShooting = true;
    }
    private void Update()
    {
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * playerSpeed * Time.deltaTime);

        print(allowShooting);
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

    IEnumerator ShootDelay()
    {
        allowShooting = false;
        yield return new WaitForSeconds(shootDelay);
        allowShooting = true;
        Debug.Log("Player Can Shoot");
    }


}