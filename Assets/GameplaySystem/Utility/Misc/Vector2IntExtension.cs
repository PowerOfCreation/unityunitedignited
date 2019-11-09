using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2IntExtension
{
    public static Vector2Int Divide(this Vector2Int v, float number)
    {
        v.x = (int) (v.x / number);
        v.y = (int) (v.y / number);

        return v;
    }
}
