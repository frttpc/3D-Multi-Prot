using UnityEngine;

namespace Frttpc
{
    [CreateAssetMenu(fileName = "Health Upgrade", menuName = "Power Ups/Health Upgrade")]
    public class HealthUpgradeSO : PowerUpSO
    {
        [SerializeField] private int healthIncrease;

        public override void Apply(GameObject collector)
        {
            collector.GetComponent<Health>().IncreaseHealth(healthIncrease);
        }
    }
}