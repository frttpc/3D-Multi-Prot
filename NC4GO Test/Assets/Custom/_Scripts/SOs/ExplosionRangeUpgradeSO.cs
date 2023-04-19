using UnityEngine;

namespace Frttpc
{
    [CreateAssetMenu(fileName = "Explosion Range Upgrade", menuName = "Scriptable Objects/Power Ups/Explosion Range Upgrade")]
    public class ExplosionRangeUpgradeSO : PowerUpSO
    {
        public override void Apply(GameObject collector)
        {
            collector.GetComponent<BombDrop>().IncreaseExplosionRange();
        }
    }
}