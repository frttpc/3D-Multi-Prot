using System;
using System.Collections.Generic;
using UnityEngine;

namespace BomberPerson
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private SpawnPointsTable spawnPointsTable;
        private List<Vector2Int> emptySpaces = new(); 

        [Header("Obtsacles")]
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private Transform obstaclesParent;
        
        [Header("Crates")]
        [SerializeField] private GameObject cratePrefab;
        [SerializeField] private Transform cratesParent;

        [Header("Size")]
        [SerializeField] [Range(2, 20)] private int xCount;
        [SerializeField] [Range(2, 20)] private int zCount;
        private int xValue;
        private int zValue;

        public bool generateMap = false;

        public static MapManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            xValue = (int)(xCount * 0.5f);
            zValue = (int)(zCount * 0.5f);

            GenerateCorners();
            AddCenterToEmptySpaces();

            if(generateMap)
                GenerateLayout();
        }

        private void GenerateLayout()
        {
            for (int x = -xValue; x <= xValue; x++)
            {
                for (int z = -zValue; z <= zValue; z++)
                {
                    if (emptySpaces.Contains(new Vector2Int(x, z)))
                    {
                        continue;
                    }
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
                        Instantiate(cratePrefab,    new Vector3Int(x, 0, z), Quaternion.identity, cratesParent);
                    }
                }
            }
        }

        private void GenerateCorners()
        {
            Vector2Int[] spawnPointsArr = spawnPointsTable.spawnPoints;

            for (int i = 0; i < spawnPointsArr.Length; i++)
            {
                Vector2Int vec = spawnPointsArr[i];
                emptySpaces.Add(new Vector2Int(vec.x * (xValue - 1), vec.y * (zValue - 1)));
                emptySpaces.Add(new Vector2Int(vec.x * (xValue - 2), vec.y * (zValue - 1)));
                emptySpaces.Add(new Vector2Int(vec.x * (xValue - 1), vec.y * (zValue - 2)));
            }
        }

        private void AddCenterToEmptySpaces() => emptySpaces.Add(Vector2Int.zero);

        public Vector2Int GetSize() => new(xValue, zValue);
    }
}