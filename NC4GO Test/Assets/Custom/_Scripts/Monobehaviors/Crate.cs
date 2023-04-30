using UnityEngine;

namespace Frttpc
{
    public class Crate : MonoBehaviour, IDamagable
    {
        [SerializeField] private ParticleSystem boxDestroyEffect;

        public void Damage()
        {
            PowerUpManager.Instance.DropRandomPowerUp(transform.position);
            Instantiate(boxDestroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}