using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Player player;
    private PlayerInput PlayerInput;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();
        var Players = FindObjectsOfType<Player>();
        var index = PlayerInput.playerIndex;
        player = Players.FirstOrDefault(p => p.GetPlayerIndex() == index);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        //player.SetInputVector(ctx.ReadValue<Vector2>());
    }



}
