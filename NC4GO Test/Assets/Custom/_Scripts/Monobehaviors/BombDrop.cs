using UnityEngine;
using UnityEngine.InputSystem;
using Frttpc.Statics;

namespace Frttpc
{
    public class BombDrop : MonoBehaviour
    {
        [SerializeField] private GameObject bombPrefab;

        private int bombCount = 1;
        private int bombExplosionRange = 1;

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
                Instantiate(bombPrefab, transform.position.toInt(), Quaternion.identity);
                //bombCount--;
            }
        }
    }
}