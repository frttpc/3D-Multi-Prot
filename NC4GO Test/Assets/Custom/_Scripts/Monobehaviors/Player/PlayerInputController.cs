using UnityEngine.InputSystem;
using UnityEngine;

namespace Frttpc
{
    public class PlayerInputController : MonoBehaviour
    {
        private PlayerInputActions playerInputActions;

        private void Awake()
        {
            playerInputActions = new();
        }

        private void OnEnable()
        {
            playerInputActions.Enable();
        }

        private void OnDisable()
        {
            playerInputActions.Disable();
        }

        public InputAction GetMovement() => playerInputActions.Player.Movement;
        public InputAction GetBombDrop() => playerInputActions.Player.BombDrop;
    }
}