using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;
using Frttpc.Statics;
using Frttpc.Interfaces;
using Frttpc.SOs;
using BomberPerson.Input;

namespace BomberPerson.BombSystem
{
    public class BombDrop : NetworkBehaviour, IGameEventListener
    {
        [SerializeField] private Bomb bombPrefab;

        [SerializeField] private GameEvent OnExplodeEvent;
        
        private int bombCount = 1;
        private float explosionRange = 1.5f;

        void Start()
        {
            InputManager.Instance.GetBombDrop().performed += DropABomb;
            OnExplodeEvent.RegisterListener(this);
        }

        new void OnDestroy()
        {
            InputManager.Instance.GetBombDrop().performed -= DropABomb;
            OnExplodeEvent.UnRegisterListener(this);
        }

        public void RaiseEvent()
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