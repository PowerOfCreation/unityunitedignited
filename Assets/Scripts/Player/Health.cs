// using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    public int health = 10;

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
