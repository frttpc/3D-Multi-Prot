using UnityEngine;
using Frttpc.Mono;
using Frttpc.SOs;

namespace BomberPerson.PowerUpSystem
{
    public class PowerUpManager : BaseGameEventListenerGeneric<Vector3, GameEventGeneric<Vector3>>
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

        public override void RaiseEvent(Vector3 pos)
        {
            DropRandomPowerUp(pos);
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

                print(randomNumber + " - " + currentTotalWeight + " = " + (randomNumber - currentTotalWeight));

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