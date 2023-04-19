using System;
using UnityEngine;

namespace Frttpc
{
    public abstract class PowerUpSO : ScriptableObject
    {
        [SerializeField] private int dropWeight;

        public event Action OnAcquire;

        public abstract void Apply(GameObject collector);

        public int GetWeight() => dropWeight;
    }
}