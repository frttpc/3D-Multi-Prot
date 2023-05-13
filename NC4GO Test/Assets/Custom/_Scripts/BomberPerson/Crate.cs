using UnityEngine;
using Frttpc.Interfaces;
using Frttpc.SOs;

namespace BomberPerson
{
    public class Crate : MonoBehaviour, IDamagable
    {
        [SerializeField] private ParticleSystem boxDestroyEffect;

        [SerializeField] private GameEventGeneric<Vector3> dropPowerUpEvent;

        public void Damage()
        {
            dropPowerUpEvent.Raise(transform.position);
            Instantiate(boxDestroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}