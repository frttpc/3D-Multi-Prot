using UnityEngine;

namespace BomberPerson.PowerUpSystem.PowerUpSOs
{
    public abstract class PowerUpSO : ScriptableObject
    {
        public abstract void Apply(GameObject collector);
    }
}