using UnityEngine;
using Unity.Netcode;
using BomberPerson.Input;
using Frttpc.Statics;

namespace BomberPerson
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] [Range(0, 1)] private float rotationSmoothness;

        private CharacterController charController;

        public override void OnNetworkSpawn()
        {
            charController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (!IsOwner) return;

            if (InputManager.Instance.GetMovement().IsPressed())
            {
                HandleMovement();
            }
        }

        private void HandleMovement()
        {
            Vector3 move = InputManager.Instance.GetMovement().ReadValue<Vector2>().normalized.XYtoXZ();
            charController.Move(moveSpeed * Time.deltaTime * move);

            float angle = Vector3.SignedAngle(Vector3.forward, move, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), rotationSmoothness);
        }

        public void IncreaseMoveSpeed(float amount) => moveSpeed += amount;
    }
}

