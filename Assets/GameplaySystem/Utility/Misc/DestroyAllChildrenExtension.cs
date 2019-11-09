using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DestroyAllChildrenExtension
{
    public static void DestroyAllChildren(this GameObject gameObject)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in gameObject.transform) children.Add(child.gameObject);
        children.ForEach(child => Object.Destroy(child));
    }

    public static void DestroyAllChildrenImmediate(this GameObject gameObject)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in gameObject.transform) children.Add(child.gameObject);
        children.ForEach(child => Object.DestroyImmediate(child));
    }
}