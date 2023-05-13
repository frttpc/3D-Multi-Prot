using UnityEngine;

namespace Frttpc.Statics
{
    public static class Extensions
    {
        public static Vector3 XYtoXZ(this Vector2 vec) => new (vec.x, 0, vec.y);

        public static Vector3 RoundToInt(this Vector3 vec) => new(Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.y), Mathf.RoundToInt(vec.z));
    }
}
