using UnityEngine;

namespace Frttpc
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private PowerUpSO powerUpSO;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger");
            powerUpSO.Apply(other.gameObject);
            Destroy(gameObject);
        }

        public PowerUpSO GetPowerUpSO() => powerUpSO;
    }
}