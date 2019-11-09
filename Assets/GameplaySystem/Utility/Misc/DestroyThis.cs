using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    public float seconds = 1f;

    void Start()
    {
        Destroy(gameObject, seconds);
    }
}