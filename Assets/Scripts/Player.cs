using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float playerSpeed = 3f;
    public Vector2 movementInput;

    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private float shootDelay = 0.1f;
    private bool allowShooting;

    [SerializeField] private InputActionReference Shoot;

    private void Update()
    {
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * playerSpeed * Time.deltaTime);

        if (Shoot.action.WasPressedThisFrame())
        {
            ShootGun();
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void ShootGun()
    {
        if (allowShooting == true)
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            StartCoroutine(ShootDelay());
            Debug.Log("Player Shooting!");
        }

        else
        {
            Debug.Log("Player Cannot Shoot");
        }
    }

    IEnumerator ShootDelay()
    {
        allowShooting = false;
        yield return new WaitForSeconds(shootDelay);
        allowShooting = true;
    }


}