using UnityEngine;
using Frttpc.SOs;
using BomberPerson.BombSystem;
using BomberPerson.UI;

namespace BomberPerson.PowerUpSystem.PowerUpSOs
{
    [CreateAssetMenu(fileName = "Bomb Upgrade", menuName = "Scriptable Objects/Power Ups/Bomb Upgrade")]
    public class BombUpgradeSO : PowerUpSO
    {
        public override void Apply(GameObject collector)
        {
            collector.GetComponent<BombDrop>().IncreaseBombCount();
            HUDManager.Instance.IncreaseBombCount();
        }
    }
}