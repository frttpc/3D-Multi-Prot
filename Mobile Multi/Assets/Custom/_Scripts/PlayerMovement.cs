using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace frttpc
{
    public class PlayerMovement : NetworkBehaviour
    {
        private PlayerInputController _playerInputController;
        private CharacterController _charController;

        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _turnSpeed;

        private void Awake()
        {
            _playerInputController = GetComponent<PlayerInputController>();
            _charController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (!IsOwner) return;

            if (_playerInputController.movement.inProgress)
            {
                Vector3 move = _playerInputController.movement.ReadValue<Vector2>().toXZ();

                _charController.Move(_moveSpeed * move * Time.deltaTime);
            }
        }
    }
}
