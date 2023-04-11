using Unity.Netcode;
using UnityEngine.InputSystem;

namespace Frttpc
{
    public class PlayerInputController : NetworkBehaviour
    {
        private PlayerInputActions playerInputActions;

        public override void OnNetworkSpawn()
        {
            playerInputActions = new();
            playerInputActions.Enable();
        }

        public override void OnNetworkDespawn()
        {
            playerInputActions.Disable();
        }

        public InputAction GetMovement() => playerInputActions.Player.Movement;

        public InputAction GetBombDrop() => playerInputActions.Player.BombDrop;

    }
}