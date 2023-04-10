using UnityEngine;
using Unity.Netcode;
using frttpc;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : NetworkBehaviour
{
    private CharacterController charController;
    private PlayerInputActions playerInputActions;

    [SerializeField] private float moveSpeed;

    public override void OnNetworkSpawn()
    {
        charController = GetComponent<CharacterController>();

        playerInputActions = new();
        playerInputActions.Enable();
    }

    public override void OnNetworkDespawn()
    {
        playerInputActions.Disable();
    }

    private void Update()
    {
        if (!IsOwner) return;

        if (playerInputActions.Player.Movement.IsInProgress())
        {
            Vector2 move = playerInputActions.Player.Movement.ReadValue<Vector2>();

            charController.Move(moveSpeed * Time.deltaTime * new Vector3(move.x, 0, move.y));
        }
    }
}
