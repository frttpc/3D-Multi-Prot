using UnityEngine;
using BomberPerson;
using BomberPerson.UI;

namespace BomberPerson.PowerUpSystem.PowerUpSOs
{
    [CreateAssetMenu(fileName = "Health Upgrade", menuName = "Scriptable Objects/Power Ups/Health Upgrade")]
    public class HealthUpgradeSO : PowerUpSO
    {
        public override void Apply(GameObject collector)
        {
            collector.GetComponent<Health>().IncreaseHealth();
            HUDManager.Instance.IncreaseHealthCount();
        }
    }
}