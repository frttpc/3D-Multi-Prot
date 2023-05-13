using UnityEngine;
using BomberPerson.BombSystem;
using BomberPerson.UI;

namespace BomberPerson.PowerUpSystem.PowerUpSOs
{
    [CreateAssetMenu(fileName = "Explosion Range Upgrade", menuName = "Scriptable Objects/Power Ups/Explosion Range Upgrade")]
    public class ExplosionRangeUpgradeSO : PowerUpSO
    {
        public override void Apply(GameObject collector)
        {
            collector.GetComponent<BombDrop>().IncreaseExplosionRange();
            HUDManager.Instance.IncreaseRangeAmount();
        }
    }
}