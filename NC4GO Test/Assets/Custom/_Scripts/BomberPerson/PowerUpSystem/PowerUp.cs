using UnityEngine;
using BomberPerson.PowerUpSystem.PowerUpSOs;

namespace BomberPerson.PowerUpSystem
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private PowerUpSO powerUpSO;

        private void OnTriggerEnter(Collider other)
        {
            powerUpSO.Apply(other.gameObject);
            Destroy(gameObject);
        }

        public PowerUpSO GetPowerUpSO() => powerUpSO;
    }
}