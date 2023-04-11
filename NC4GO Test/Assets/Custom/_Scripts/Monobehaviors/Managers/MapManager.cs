using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frttpc
{
    public class MapManager : MonoBehaviour
    {
        [Header("Obtsacles")]
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private Transform obstaclesParent;
        
        [Header("Crates")]
        [SerializeField] private GameObject cratePrefab;
        [SerializeField] private Transform cratesParent;

        [Header("Size")]
        [SerializeField] [Range(2, 20)] private int xValue;
        [SerializeField] [Range(2, 20)] private int zValue;

        public static MapManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //GenerateLayout();
        }

        private void GenerateLayout()
        {
            for (int x = -xValue; x <= xValue; x++)
            {
                for (int z = -zValue; z <= zValue; z++)
                {
                    if (x == xValue || x == -xValue || z == zValue || z == -zValue)
                    {
                        Instantiate(obstaclePrefab, new Vector3Int(x, 0, z), Quaternion.identity, obstaclesParent);
                    }
                    else if(x % 2 == 0 && z % 2 == 0)
                    {
                        Instantiate(obstaclePrefab, new Vector3Int(x, 0, z), Quaternion.identity, obstaclesParent);
                    }
                    else
                    {
                        Instantiate(cratePrefab, new Vector3Int(x, 0, z), Quaternion.identity, cratesParent);
                    }
                }
            }
        }
    }
}