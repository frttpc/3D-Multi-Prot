using UnityEngine;
using UnityEngine.InputSystem;
using Frttpc.Statics;

namespace Frttpc
{
    public class BombDrop : MonoBehaviour
    {
        [SerializeField] private Bomb bombPrefab;

        private int bombCount = 1;
        private int explosionRange = 1;

        private PlayerInputController playerInputController;

        private void Awake()
        {
            playerInputController = GetComponent<PlayerInputController>();
        }

        private void OnEnable()
        {
            playerInputController.GetBombDrop().performed += DropABomb;
        }

        private void OnDestroy()
        {
            playerInputController.GetBombDrop().performed -= DropABomb;
        }

        private void DropABomb(InputAction.CallbackContext context)
        {
            if(bombCount > 0)
            {
                Instantiate(bombPrefab, transform.position.RoundToInt(), Quaternion.identity);
                bombCount--;
            }
        }

        public void IncreaseBombCount() => bombCount++;

        public void IncreaseExplosionRange()
        {
            bombPrefab.IncreaseRange();
            explosionRange++;
        }
    }
}