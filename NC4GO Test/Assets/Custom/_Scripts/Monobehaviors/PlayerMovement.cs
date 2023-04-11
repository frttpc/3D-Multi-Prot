using UnityEngine;
using Unity.Netcode;
using Frttpc;
using Frttpc.Statics;

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

        if (playerInputController.GetMovement().IsPressed())
        {
            Vector3 move = playerInputController.GetMovement().ReadValue<Vector2>().normalized.XYtoXZ();
            charController.Move(moveSpeed * Time.deltaTime * move);

            float angle = Vector3.SignedAngle(Vector3.forward, move, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), rotationSmoothness);
        }
    }
}
