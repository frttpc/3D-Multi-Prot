using UnityEngine;

namespace Frttpc.Statics
{
    public static class Extensions
    {
        public static Vector3 XYtoXZ(this Vector2 vec) => new (vec.x, 0, vec.y);

        public static Vector3 toInt(this Vector3 vec) => new((int)vec.x, (int)vec.y, (int)vec.z);
    }
}
