using UnityEngine.InputSystem;
using UnityEngine;

namespace Frttpc
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInputActions playerInputActions;

        public static InputManager Instance;

        private void Awake()
        {
            Instance = this;
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