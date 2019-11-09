using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RayExtension
{
    public static void DrawRay(this Ray ray)
    {
        Debug.DrawRay(ray.origin, ray.direction);
    }

    public static void DrawRay(this Ray ray, Color color, float duration = 0.2f)
    {
        Debug.DrawRay(ray.origin, ray.direction, color, duration);
    }
}