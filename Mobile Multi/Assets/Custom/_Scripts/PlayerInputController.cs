using UnityEngine;
using UnityEngine.InputSystem;

namespace frttpc
{
    public class PlayerInputController : MonoBehaviour
    {
        private InputActionAsset playerInputActions;
        private InputActionMap player;
        public InputAction movement { get; private set; }

        private void Awake()
        {
            playerInputActions = GetComponent<PlayerInput>().actions;
            player = playerInputActions.FindActionMap("Player");
        }

        private void OnEnable()
        {
            player.Enable();
            movement = player.FindAction("Movement");
        }

        private void OnDisable()
        {
            player.Disable();
        }
    }
}
