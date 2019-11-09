using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAlcohol : MonoBehaviour
{
    void OnTriggerEnter2D( )
    {
        Debug.Log("Alcohol taken");
        Destroy(gameObject);
    }
}
