using UnityEngine;
using BomberPerson.UI;

namespace BomberPerson.PowerUpSystem.PowerUpSOs
{
    [CreateAssetMenu(fileName = "Speed Upgrade", menuName = "Scriptable Objects/Power Ups/Speed Upgrade")]
    public class SpeedUpgradeSO : PowerUpSO
    {
        [SerializeField] private float speedUpgradeAmount;

        public override void Apply(GameObject collector)
        {
            collector.GetComponent<PlayerMovement>().IncreaseMoveSpeed(speedUpgradeAmount);
            HUDManager.Instance.IncreaseSpeedAmount();
        }
    }
}