using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;
    public float speed;
    public float atkDelay = 1;
    public int damage = 1;
    private int health;
    [HideInInspector]
    public Transform player;

    public virtual void Start() {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void TakeDamage(int amount){
        health -= amount;

        if(health <= 0){
            Debug.Log("Enemy Dead");
        }
    }
}
