using UnityEngine;
using System.Collections.Generic;

namespace Frttpc
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> powerUp;

        private int _totalWeight;

        public static PowerUpManager Instance;

        private void Start()
        {
            SumTotalWeight();
        }

        private void RandomDropPowerUp()
        {
            int randomNumber = Random.Range(0, _totalWeight);

            //if(Random.Range(0, 100) <= )
        }

        private void SumTotalWeight()
        {
            foreach (Transform powerUp in powerUp)
            {
                _totalWeight += powerUp.GetComponent<PowerUp>().GetPowerUpSO().GetWeight();
            }
        }
    }
}