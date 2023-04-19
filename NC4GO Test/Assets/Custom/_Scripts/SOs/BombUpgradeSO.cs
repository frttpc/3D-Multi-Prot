using UnityEngine;

namespace Frttpc
{
    [CreateAssetMenu(fileName = "Bomb Upgrade", menuName = "Scriptable Objects/Power Ups/Bomb Upgrade")]
    public class BombUpgradeSO : PowerUpSO
    {
        public override void Apply(GameObject collector)
        {
            collector.GetComponent<BombDrop>().IncreaseBombCount();
        }
    }
}