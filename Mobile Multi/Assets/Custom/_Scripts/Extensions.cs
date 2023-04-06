using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace frttpc
{
    public static class Extensions
    {
        public static Vector3 toXZ(this Vector2 vector2) =>  new Vector3(vector2.x, 0, vector2.y);
    }
}
