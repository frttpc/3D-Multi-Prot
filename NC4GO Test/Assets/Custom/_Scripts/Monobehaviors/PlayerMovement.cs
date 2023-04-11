using UnityEngine;
using Unity.Netcode;
using Frttpc;
using Frttpc.Extensions;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] [Range(0, 1)] private float rotationSmoothness;

    private CharacterController charController;
    private PlayerInputController playerInputController;

    public override void OnNetworkSpawn()
    {
        charController = GetComponent<CharacterController>();
        playerInputController = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        if (!IsOwner) return;

        if (playerInputController.GetMovement().IsInProgress())
        {
            Vector3 move = playerInputController.GetMovement().ReadValue<Vector2>().normalized.XYtoXZ();

            charController.Move(moveSpeed * Time.deltaTime * move);
            transform.rotation = Quaternion.Lerp(transform.rotation, move., rotationSmoothness);
        }
    }
}
