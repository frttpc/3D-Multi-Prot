using UnityEngine;

namespace Frttpc.Statics
{
    public static class Extensions
    {
        public static Vector3 XYtoXZ(this Vector2 vec) => new (vec.x, 0, vec.y);
    }
}
