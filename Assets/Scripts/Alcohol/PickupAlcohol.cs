using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAlcohol : MonoBehaviour
{
    public static int healAmount = 1;

    void OnTriggerEnter2D( )
    {
        GameManager.Instance.GetLocalPlayer().GetComponentInChildren<PlayerHealth>().Heal(healAmount);
        Destroy(gameObject);
    }
}
