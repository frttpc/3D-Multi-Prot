using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;
using Frttpc.Statics;

namespace Frttpc
{
    public class BombDrop : NetworkBehaviour, IGameEventListener
    {
        [SerializeField] private Bomb bombPrefab;

        //for increase bomb count ondetonate
        [SerializeField] private GameEvent OnExplodeEvent;
        
        private int bombCount = 1;
        private int explosionRange = 1;

        void Start()
        {
            InputManager.Instance.GetBombDrop().performed += DropABomb;
            OnExplodeEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            InputManager.Instance.GetBombDrop().performed -= DropABomb;
            OnExplodeEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            IncreaseBombCount();
        }

        private void DropABomb(InputAction.CallbackContext context)
        {
            if (!IsOwner) return;
            if (bombCount <= 0) return;

            Bomb newBomb = Instantiate(bombPrefab, transform.position.RoundToInt(), Quaternion.identity);
            newBomb.SetRange(explosionRange);
            newBomb.GetComponent<NetworkObject>().Spawn(true);

            bombCount--;
        }

        public void IncreaseBombCount() => bombCount++;

        public void IncreaseExplosionRange() => explosionRange++;
        
    }
}