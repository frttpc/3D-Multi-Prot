using UnityEngine;
using System.Collections.Generic;

namespace Frttpc
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private DropTableSO dropTableSO;

        private int _totalWeight;

        public static PowerUpManager Instance;

        private void Start()
        {
            SumTotalWeight();

        }

        public void DropRandomPowerUp(Vector3 pos)
        {
            Transform prefab = ChooseAPowerUp();

            if (prefab != null)
                Instantiate(prefab, pos, Quaternion.identity);
        }

        private Transform ChooseAPowerUp()
        {
            int randomNumber = Random.Range(0, _totalWeight + 1);

            //Random choice with weights

            return null;
        }

        private void SumTotalWeight()
        {
            for (int i = 0; i < dropTableSO.dropTable.Length; i++)
            {
                _totalWeight += dropTableSO.dropTable[i].dropWeight;
            }
        }
    }
}