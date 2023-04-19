using System;
using UnityEngine;

namespace Frttpc
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private int health = 3;

        public event Action OnDeath;

        public void Damage()
        {
            if (--health == 0) Die();
        }

        public void IncreaseHealth(int amount)
        {
            health += amount;
        }

        public void Die()
        {
            OnDeath?.Invoke();
            print("Ded");
        }
    }
}