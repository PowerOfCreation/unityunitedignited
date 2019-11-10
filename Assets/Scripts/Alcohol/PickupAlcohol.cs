using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAlcohol : MonoBehaviour
{
    public static int healAmount = 1;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player")
        {
            Player.self.GetComponentInChildren<PlayerHealth>().Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
