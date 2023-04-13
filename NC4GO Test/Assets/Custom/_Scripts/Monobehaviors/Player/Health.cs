using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frttpc
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private int health = 3;

        public void Damage()
        {
            if (--health == 0) Die();
        }

        public void Die()
        {
            print("Ded");
        }
    }
}