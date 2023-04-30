using UnityEngine;
using System.Collections.Generic;

namespace Frttpc
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private DropTableSO dropTableSO;

        private int _totalWeight;

        public static PowerUpManager Instance;

        private void Awake()
        {
            Instance = this;
        }

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
            int currentTotalWeight = 0;

            for (int i = 0; i < dropTableSO.dropTable.Length; i++)
            {
                currentTotalWeight += dropTableSO.dropTable[i].dropWeight;

                if (randomNumber - currentTotalWeight <= 0)
                    return dropTableSO.dropTable[i].powerUpPrefab;
            }

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