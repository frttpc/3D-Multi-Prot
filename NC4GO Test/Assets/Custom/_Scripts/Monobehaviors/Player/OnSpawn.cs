using UnityEngine;
using Unity.Netcode;

namespace Frttpc
{
    public class OnSpawn : NetworkBehaviour
    {
        [SerializeField] private SpawnPointsTable spawnPointsTable;

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();

            Vector2Int vec = spawnPointsTable.spawnPoints[OwnerClientId];
            Vector2Int mapSize = MapManager.Instance.GetSize();
            transform.position = new(vec.x * (mapSize.x - 1), 0, vec.y * (mapSize.y - 1));
        }
    }
}