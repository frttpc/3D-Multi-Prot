using System;
using UnityEngine;

namespace Frttpc
{
    public abstract class PowerUpSO : ScriptableObject
    {
        public event Action OnAcquire;

        public abstract void Apply(GameObject collector);
    }
}