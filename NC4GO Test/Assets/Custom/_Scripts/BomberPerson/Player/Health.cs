using System;
using UnityEngine;
using Frttpc.Interfaces;

namespace BomberPerson
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private int health = 3;

        [SerializeField] private Animator playerAnimator;

        public void Damage()
        {
            if (--health == 0) Die();
            playerAnimator.Play("Take Damage");
        }

        public void IncreaseHealth()
        {
            health++;
        }

        public void Die()
        {
            print("Ded");
        }
    }
}