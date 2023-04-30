using UnityEngine;

namespace Frttpc
{
    [CreateAssetMenu(menuName = "Scriptable Objects /Spawn Points Table")]
    public class SpawnPointsTable : ScriptableObject
    {
        public Vector2Int[] spawnPoints;
    }
}